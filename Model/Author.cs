using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Author's Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Author's LastName is required!")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Author's Age is required!")]
        public int Age { get; set; }
    }
}
