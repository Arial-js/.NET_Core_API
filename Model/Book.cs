using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Book's Title is required!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Book's Description is required!")]
        public string Description { get; set; }
        public virtual Author Author { get; set; }
    }
}
