using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MasterMoney.Models
{
    public class Notes
    {
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
