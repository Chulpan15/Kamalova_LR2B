using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kamalova_LR2B.Models
{
    public class Books
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public List<Authors> Authors { get; set; }
        public int Year { get; set; }

    }
}
