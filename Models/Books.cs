using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Kamalova_LR2B.Models
{
    public class Books
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }


        public Books (int ID, string Title, string Author, string ShortDesc, int Year)
        {
            this.ID = ID;
            this.Title = Title;
            this.Author = Author;
            this.ShortDesc = ShortDesc;
            this.Year = Year;
        }
    }



}
