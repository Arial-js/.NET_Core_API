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
        [MaxLength(20, ErrorMessage = "Name max lenght must be 20 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Author's LastName is required!")]
        [MaxLength(20, ErrorMessage = "Lastname max lenght must be 20 characters")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Author's Age is required!")]
        [Range(18,80, ErrorMessage = "Your age must be min 18 max 80")]
        public int Age { get; set; }
    }
}
