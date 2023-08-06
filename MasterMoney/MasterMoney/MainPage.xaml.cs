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
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            /*StackLayout stackLayout = new StackLayout();

            Label label = new Label();

            label.Text = "Hey";
            label.TextColor = Color.Cyan;
            label.FontSize = 20;
            label.FontAttributes = FontAttributes.Bold;
            label.Margin = 60;
            label.HorizontalTextAlignment = TextAlignment.Center;

            Content = stackLayout;

            Button button = new Button();

            button.Text = "OK";
            button.TextColor = Color.Red;
            button.FontSize = 20;
            button.FontAttributes = FontAttributes.Bold;
            button.BackgroundColor = Color.White;

            button.HorizontalOptions = LayoutOptions.CenterAndExpand;
            button.Margin = 60;

            Entry input = new Entry();
            input.Placeholder = "ABOBA";
            input.IsPassword = false;
            input.FontSize = 20;
            input.FontAttributes = FontAttributes.Bold;
            input.BackgroundColor = Color.White;
            input.Margin = 60;
            input.TextColor = Color.Red;


            Entry entry = new Entry()
            {
                Text = "OK",
                TextColor = Color.Blue
            };

            stackLayout.Children.Add(label);
            stackLayout.Children.Add(input);
            stackLayout.Children.Add(button);

            StackLayout stackLayout2 = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };

            Label label1 = new Label()
            {
                Text = "Ya ABOBA",
                FontSize = 100,
                FontAttributes = FontAttributes.Italic
            };

            CheckBox checkBox = new CheckBox()
            {
                IsChecked = true
                
            };

            stackLayout2.Children.Add(label1);
            stackLayout2.Children.Add(checkBox);
            stackLayout.Children.Add(stackLayout2);
            Content.BackgroundColor = Color.Blue;*/
            button.Clicked += Button_Clicked;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Notification", "You are loser", "I agree");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
