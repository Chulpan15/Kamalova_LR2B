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
        public List<Authors> Authors { get; set; }
        public int Year { get; set; }


        public Books (int ID, string Title, string ShortDesc, int Year)
        {
            this.ID = ID;
            this.Title = Title;
            this.ShortDesc = ShortDesc;
            this.Authors = Authors;
            //this.Year = Year;
        }
    }



}
