using MasterMoney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterMoney.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class AddPage : ContentPage
    {
        public string ItemId 
        {
            set 
            { 
                LoadNote(value);
            }
        }
        private async void LoadNote(string value) 
        {
            try
            {
                int id = Convert.ToInt32(value);
                Notes note = await App.NotesDB.GetNotesByIdAsync(id);
                BindingContext = note;
            }
            catch { }
        }
        public AddPage()
        {
            InitializeComponent();
            BindingContext = new Notes();
            dateEntry.Text = DateTime.Today.ToString();
        }

        private async void ButtonAddTournament_Clicked(object sender, EventArgs e)
        {
            Notes note = (Notes)BindingContext;

            note.Date = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(note.Text))
            {
                await App.NotesDB.SaveNoteAsync(note);
            }

            await Shell.Current.GoToAsync("..");

        }

        private async void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void ButtonPrizeMoney_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(PrizeMoney));
        }
    }
}