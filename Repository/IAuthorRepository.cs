using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> Get();
        Task<Author> Get(int id);
        Task<Author> Create(Author author);
        Task Update(Author author);
        Task Delete(int id);
    }
}
