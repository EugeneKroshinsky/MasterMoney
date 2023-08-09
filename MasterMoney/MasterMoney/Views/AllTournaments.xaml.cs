using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MasterMoney.Models;

namespace MasterMoney.Views
{
    public partial class AllTournaments : ContentPage
    {
        public AllTournaments()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            сollectionView.ItemsSource = await App.NotesDB.GetNotesAsync();
            NavigationPage.SetHasNavigationBar(this, false);

            base.OnAppearing();
        }
        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddPage));
        }

        /*private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }*/
    }
}