using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _authorRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            return await _authorRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostAuthors([FromBody] Author author)
        {
            var newAuthor = await _authorRepository.Create(author);
            return CreatedAtAction(nameof(GetAuthor), new { id = newAuthor.Id }, newAuthor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAuthor(int id, [FromBody] Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }
            await _authorRepository.Update(author);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBooks(int id)
        {
            var authorToDelete = await _authorRepository.Get(id);
            if (authorToDelete == null)
                return NotFound();

            await _authorRepository.Delete(authorToDelete.Id);
            return NoContent();
        }
    }
}
