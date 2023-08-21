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
        public string Date { get; set; }
        public bool IsChecked { get; set; }
    }
}
