using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Kamalova_LR2B.Models;

namespace Kamalova_LR2B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        //Books[] Books = new Books[]
        //{
        //    new Books { ID = 1, Title = "Pride and Prejudice", Year = 1813, ShortDesc = "Romantic story"},
        //    new Books { ID = 2, Title = "The Master and Margarita", Year = 1966, ShortDesc = "Fantastic and ironically philosophical"}

        //};

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks()
        {
          if (_context.Books == null)
          {
              return NotFound();
          }
            return await _context.Books.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Books>> GetBooks(int id)
        {
          if (_context.Books == null)
          {
              return NotFound();
          }
            var books = await _context.Books.FindAsync(id);

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooks(int id, Books books)
        {
            if (id != books.ID)
            {
                return BadRequest();
            }

            _context.Entry(books).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Books>> PostBooks(Books books)
        {
          if (_context.Books == null)
          {
              return Problem("Entity set 'AuthorsContext.Books'  is null.");
          }

            var bookss = new Books(books.ID, books.Title, books.Author, books.ShortDesc, books.Year);
            _context.Books.Add(bookss);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooks", new { id = books.ID }, books);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooks(int id)
        {
            if (_context.Books == null)
            {
                return NotFound();
            }
            var books = await _context.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }

            _context.Books.Remove(books);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BooksExists(int id)
        {
            return (_context.Books?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
