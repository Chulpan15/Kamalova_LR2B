﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Kamalova_LR2B.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Kamalova_LR2B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly LibraryContext _context;

        //Authors[] Authors = new Authors[]
        //    {
        //        new Authors { Id = 1, Surname = "Ostin", Name = "Jane", Yearbirth = 1775},
        //        new Authors { Id = 2, Surname = "Bulgakov", Name = "Mihail", Yearbirth = 1891}
        //    };


        public AuthorsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Authors>>> GetAuthors()
        {
          if (_context.Authors == null)
          {
              return NotFound();
          }
            return await _context.Authors.ToListAsync();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Authors>> GetAuthors(int id)
        {
            if (_context.Authors == null)
            {
                return NotFound();
            }
            var authors = await _context.Authors.FindAsync(id);

            if (authors == null)
            {
                return NotFound();
            }

            return authors;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthors(int id, Authors authors)
        {
            if (id != authors.Id)
            {
                return BadRequest();
            }

            _context.Entry(authors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorsExists(id))
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

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Authors>> PostAuthors(Authors authors)
        {
          if (_context.Authors == null)
          {
              return Problem("Entity set 'LibraryContext.Authors'  is null.");
            }
           var authorss = new Authors(authors.Id, authors.Surname, authors.Name, authors.Yearbirth);
           _context.Authors.Add(authorss);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthors", new { id = authors.Id }, authors);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthors(int id)
        {
            if (_context.Authors == null)
            {
                return NotFound();
            }
            var authors = await _context.Authors.FindAsync(id);
            if (authors == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(authors);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorsExists(int id)
        {
            return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        //[HttpGet("GetRequestsByAuthor")]
        //public async Task<ActionResult<IEnumerable<Authors>>> GetRequests(string Surname, int )
        //{
        //    if (_context.Books == null)
        //    {
        //        return NotFound();
        //    }

        //    //var result = await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Title == Title);
        //    var results = await _context.Books
        //        .Where(b => b.Title == Title)
        //        .Include(b => b.Author)
        //        .ToListAsync();

        //    if (results == null)
        //    {
        //        return NotFound();
        //    }

        //    return results;
        //}
    }
}
