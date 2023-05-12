using Kamalova_LR2B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kamalova_LR2B.Interfaces
{
    public interface IAllBooks
    {
        IEnumerable<Books> Books { get; }
        Books getObjectBook(int BookId);
    }
}
