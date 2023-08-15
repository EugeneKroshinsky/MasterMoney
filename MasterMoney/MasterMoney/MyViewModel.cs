using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MasterMoney
{
    public class MyViewModel : INotifyPropertyChanged
    {
        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set
            {
                if (name == value) { return; }

                name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(DisplayName));
            }
        }


        public string DisplayName()
        {
            if(!int.TryParse(Name, out int num))
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
