using MasterMoney.GameLogic;
using MasterMoney.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MasterMoney.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class AddPage : ContentPage
    {
        int[] Coefficients; //здесь будут храниться деньги за выигранный матч и выигранный сет в прогиранной игре в разных лигах 
        MasterMoney.GameLogic.Match groupMatch1, groupMatch2, groupMatch3, semifinal, final;
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
            dateEntry.Date = DateTime.Now;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        private async void ButtonAddTournament_Clicked(object sender, EventArgs e)
        {
            Notes note = Calculate();
            if (note is null)
            {
                return;
            }
            else
            {
                await App.NotesDB.SaveNoteAsync(note);
                await Shell.Current.GoToAsync("..");
            }
        }
        private Notes Calculate()
        {

            /*string pattern = @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{2}$";

            if (!Regex.IsMatch(tournamentDateString, pattern))
            {
                DisplayAlert("Ошибка при вводе даты", "Недопустимое значение при вводе, убедитесь, что дата введена правильно", "ОK");
                return null;
            }*/

            if (!(int.TryParse(entry1.Text, out int res1) && int.TryParse(entry2.Text, out int res2) &&
            int.TryParse(entry3.Text, out int res3) && int.TryParse(entry4.Text, out int res4) && int.TryParse(entry5.Text, out int res5)))
            {
                DisplayAlert("Ошибка при вводе сетов", "Недопустимое значение при вводе, убедитесь, что введённые сеты являются целыми числами ", "ОK");
                return null;
            }

            if (label1.Text.Equals("?") || label2.Text.Equals("?") || label3.Text.Equals("?") || label4.Text.Equals("?") || label5.Text.Equals("?"))
            {
                DisplayAlert("Ошибка при вводе сетов", "Недопустимое значение при в   воде, убедитесь, что введённые сеты больше или равны 0 и меньше или равны 4 ", "ОK");
                return null;
            }

            switch (picker.SelectedIndex)
            {
                case 0:
                    Coefficients = new int[] { 80, 18, 90, 20, 100, 24, 140, 40 };
                    break;
                case 1:
                    Coefficients = new int[] { 40, 9, 45, 10, 50, 12, 70, 20 };
                    break;
                case 2:
                    Coefficients = new int[] { 30, 6, 35, 7, 40, 8, 60, 16 };
                    break;
                case 3:
                    Coefficients = new int[] { 25, 5, 30, 6, 35, 7, 55, 14 };
                    break;
                default:
                    DisplayAlert("Ошибка при выборе лиги", "Пожалуйста, выберите лигу", "ОK");
                    return null;
            }

            groupMatch1 = new MasterMoney.GameLogic.Match(res1, Coefficients[0], Coefficients[1]);
            groupMatch2 = new MasterMoney.GameLogic.Match(res2, Coefficients[0], Coefficients[1]);
            groupMatch3 = new MasterMoney.GameLogic.Match(res3, Coefficients[0], Coefficients[1]);
            semifinal = new MasterMoney.GameLogic.Match(res4, Coefficients[2], Coefficients[3]);
            final = new MasterMoney.GameLogic.FinalMatch(res5, semifinal, Coefficients[4], Coefficients[5], Coefficients[6], Coefficients[7]);

            int result = (groupMatch1.matchMoney() + groupMatch2.matchMoney() + groupMatch3.matchMoney() + semifinal.matchMoney() + final.matchMoney());

            string textResult = result.ToString() + " BYN " + picker.Items[picker.SelectedIndex].ToString();
            DisplayAlert("Ваши призовые составили: ", textResult, "ОK");

            Notes note = new Notes();
            note.Date = dateEntry.Date;
            note.Money = result;
            note.IsChecked = false;
            return note;

        }
        private async void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        private void Entry_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            label1.Text = Match((sender as Xamarin.Forms.Entry).Text);
        }

        private void Entry_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            label2.Text = Match((sender as Xamarin.Forms.Entry).Text);
        }

        private void ButtonCalculate_Clicked(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Entry_TextChanged_3(object sender, TextChangedEventArgs e)
        {
            label3.Text = Match((sender as Xamarin.Forms.Entry).Text);
        }

        private void Entry_TextChanged_4(object sender, TextChangedEventArgs e)
        {
            label4.Text = Match((sender as Xamarin.Forms.Entry).Text);
        }

        private void Entry_TextChanged_5(object sender, TextChangedEventArgs e)
        {
            label5.Text = Match((sender as Xamarin.Forms.Entry).Text);
        }

        private string Match(string set) //метод для проверки правильности ввода сетов
        {
            if (!int.TryParse(set, out int num))
            {
                return "?";
            }
            if (num >= 0 && num < 4)
            {
                return "4";
            }
            else if (num == 4)
            {
                return "x";
            }
            else
            {
                return "?";
            }
        }
    }
}