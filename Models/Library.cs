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
        public int Id { get; set; }
        public IList<Authors>? authors { get; set; }

        public IList<Books>? Books { get; set; }

        public Library()
        {
            Books = new List<Books>();
        }

        public Library(int id, IList<Authors>? authors, IList<Books>? books)
        {
            Id = id;
            //Authors = authors;
            Books = books;
          //  Author = authors;
            //{
            //    Id = Id,
            //    Surname = Surname,
            //    Name = Name,
            //    Yearbirth = Yearbirth
            //};
        }

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
