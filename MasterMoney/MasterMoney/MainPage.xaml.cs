using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterMoney
{
    public partial class MainPage : ContentPage
    {
        public const double LABEL_FONT = 30;
        public const string SCORE_PLACEHOLDER = "0";
        public const double BUTTON_MARGIN = 5;
        public const double BUTTON_FONT = 25;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
