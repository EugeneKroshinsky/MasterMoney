using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using MasterMoney.Models;
using System.Threading.Tasks;

namespace MasterMoney.Data
{
    public class NotesDB
    {
        readonly SQLiteAsyncConnection db;
        public NotesDB(string connectionString)
        {
            db = new SQLiteAsyncConnection(connectionString);

            db.CreateTableAsync<Notes>().Wait();
        }

        public Task<List<Notes>> GetNotesAsync() 
        {
             return db.Table<Notes>().ToListAsync();
        }

        public Task<Notes> GetNotesByIdAsync(int id) 
        {
             return db.Table<Notes>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveNoteAsync(Notes notes)
        {
            if (notes.Id != 0)
            {
                return db.UpdateAsync(notes);
            }
            else 
            {
                return db.InsertAsync(notes);
            }
        }

        public Task DeleteNoteAsync(Notes node)
        {
            return db.DeleteAsync(node.Id);  
        }
    }
}
