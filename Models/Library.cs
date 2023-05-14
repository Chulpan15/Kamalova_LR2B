using Kamalova_LR2B.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Text.Json;

namespace Kamalova_LR2B.Models
{
    public class Library
    {
        public int id { get; set; }
        public IList<Authors>? authors { get; set; }
        public IList<Books>? Books { get; set; }

        public Library()
        {
            Books = new List<Books>();
            authors = new List<Authors>();
        }

        public Library(IList<Authors>? authors, IList<Books>? books)
        {
            this.id = id;
            this.authors = authors;
            Books = books;
        }



        //public Library(int id, IList<Authors>? authors, IList<Books>? books)
        //{
        //    this.id = id;
        //    authors = authors;
        //    Books = books;
        //}


        //public void AddAuthors(Authors authors)
        //{
        //    Authors.Add(authors);
        //}

        //public void DeleteAuthors(Authors authors)
        //{
        //    Authors.Remove(authors);
        //}

    }
}
