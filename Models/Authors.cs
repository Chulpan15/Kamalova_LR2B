using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kamalova_LR2B.Models
{
    public class Authors
    {
        public int Id { set; get;  }
        public string Surname { set; get; }
        public string Name { set; get; }
        public int Yearbirth { set; get; }
        public List<Books> Books { set; get; }
    }
}
