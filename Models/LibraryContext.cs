//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Data.Sqlite;
using Kamalova_LR2B.Models;

namespace Kamalova_LR2B.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Library>().HasMany(lib => lib.Books).WithMany();
        }

        public DbSet<Kamalova_LR2B.Models.Authors> Authors { get; set; }
        public DbSet<Kamalova_LR2B.Models.Books> Books { get; set; }
        public DbSet<Kamalova_LR2B.Models.Library> Library { get; set; } = default!;
        public DbSet<Kamalova_LR2B.Models.User> User { get; set; } = default!;
        //public DbSet<Kamalova_LR2B.Models.Request> Request { get; set; } = default!;
    }
}
