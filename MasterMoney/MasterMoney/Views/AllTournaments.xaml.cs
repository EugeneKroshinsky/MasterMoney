using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MasterMoney.Models;
using System.Security.Cryptography;

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
        private async void ButtonPrizeMoney_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(PrizeMoney));
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Notes selectedItem = (Notes)button.BindingContext;
            await App.NotesDB.DeleteNoteAsync(selectedItem);
            сollectionView.ItemsSource = null;
            сollectionView.ItemsSource = await App.NotesDB.GetNotesAsync();

        }

        private async void noteCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            Notes selectedItem = (Notes)checkBox.BindingContext;
            if(selectedItem != null)
            {
                selectedItem.IsChecked = e.Value;
                await App.NotesDB.SaveNoteAsync(selectedItem);
            }
        }
    }
}