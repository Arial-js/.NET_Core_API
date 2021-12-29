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
        [MaxLength(30, ErrorMessage = "Title max lenght must be 30 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Book's Description is required!")]
        [MaxLength(255, ErrorMessage = "Description max lenght must be 255 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You must add the Author of this book")]
        public virtual Author Author { get; set; }
    }
}
