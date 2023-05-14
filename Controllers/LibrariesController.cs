using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kamalova_LR2B.Models;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Kamalova_LR2B.Interfaces;

namespace Kamalova_LR2B.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private readonly LibraryContext _context;

        public LibrariesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Library
        //[HttpGet]
        // public async Task<ActionResult<IEnumerable<Library>>> GetLibrary()
        // {
        //     if (_context.Library == null)
        //     {
        //         return NotFound();
        //     }
        //     return await _context.Library.Include(a => a.Surname).ToListAsync();
        // }

        // GET: api/Library/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Library>> GetLibrary(int id)
        {
            if (_context.Library == null)
            {
                return NotFound();
            }
            var library = await _context.Library.FindAsync(id);

            if (library == null)
            {
                return NotFound();
            }

            return library;
        }

        // PUT: api/Library/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibrary(int id, Library library)
        {
            if (id != library.id)
            {
                return BadRequest();
            }

            _context.Entry(library).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryExists(id))
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

        // POST: api/Library
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Library>> PostLibrary(Library library)
        {
            if (_context.Library == null)
            {
                return Problem("Entity set 'LibraryContext.Library'  is null.");
            }
            var libraryy = new Library(library.authors, library.Books);
            _context.Library.Add(libraryy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibrary", new { id = library.id }, library);
        }

        // DELETE: api/Library/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibrary(int id)
        {
            if (_context.Library == null)
            {
                return NotFound();
            }
            var library = await _context.Library.FindAsync(id);
            if (library == null)
            {
                return NotFound();
            }

            _context.Library.Remove(library);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibraryExists(int id)
        {
            return (_context.Library?.Any(e => e.id == id)).GetValueOrDefault();
        }


        //мои функции

        [HttpPut()]
        [Route("AddAuthors")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> AddAuthors(int dayId, int AuthorsId)
        {
            var authors = _context.Authors.Where(a => a.Id == AuthorsId).FirstOrDefault();

            var library = _context.Authors.Where(lib => lib.Id == dayId).FirstOrDefault();

            library.AddAuthors(authors);
            _context.Entry(library).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        //[HttpDelete()]
        //[Route("DeleteAuthors")]
        //[Authorize(Roles = "user")]

        //public async Task<IActionResult> DeleteAuthors(int dayId, int AuthorsId)
        //{
        //    var authors = _context.Authors.Where(a => a.Id == AuthorsId).FirstOrDefault();

        //    var library = _context.Library.Where(lib => lib.Id == dayId).FirstOrDefault();

        //    library.DeleteAuthors(authors);
        //    _context.Entry(library).State = EntityState.Modified;
        //    _context.SaveChanges();

        //    return NoContent();
        //}


    }

}