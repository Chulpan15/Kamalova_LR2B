using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Kamalova_LR2B.Models
{
    public class Authors
    {
        public int Id { set; get;  }
        public string Surname { set; get; }
        public string Name { set; get; }
        public int Yearbirth { set; get; }
        public List<Books> Books { set; get; }


        public Authors(int Id, string Surname, string Name, int Yearbirth)
        {
            this.Id = Id;
            this.Surname = Surname;
            this.Name = Name;
            this.Yearbirth = Yearbirth;
           // this.Books = Books;
        }

    }

}

