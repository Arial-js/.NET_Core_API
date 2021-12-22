using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookContext _context;

        public AuthorRepository(BookContext context)
        {
            _context = context;
        }
        public async Task<Author> Create(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task Delete(int id)
        {
            var authorToDelete = await _context.Authors.FindAsync(id);
            _context.Authors.Remove(authorToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> Get()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> Get(int id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task Update(Author author)
        {
            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
