using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MasterMoney.Data;
using System.IO;
using MasterMoney.Views;

namespace MasterMoney
{
    public partial class App : Application
    {


        static NotesDB notesDB;

        public static NotesDB NotesDB
        {
            get
            {
                if (notesDB == null)
                {
                    notesDB = new NotesDB(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                        "NotesDataBase.db3"));
                }
                return notesDB;
            }
        }
        public App()
        {
            InitializeComponent(); 
            MainPage = new AppShell();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
