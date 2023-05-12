using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Kamalova_LR2B.Models;

namespace Kamalova_LR2B.Models
{
    public class AuthorsContext : DbContext
    {
        public AuthorsContext(DbContextOptions<AuthorsContext> options)
                : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
    }
}
