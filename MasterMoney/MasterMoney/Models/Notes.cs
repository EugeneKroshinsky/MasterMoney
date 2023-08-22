using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace MasterMoney.Models
{
    [Table("Notes")]
    public class Notes
    {
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; }
        public int Money { get; set; }
        public DateTime Date { get; set; }
        public string stringDate 
        { 
            get
            {
                return Date.ToString("dd.MM.yy");
            } 
        }
        public bool IsChecked { get; set; }
    }
}
