using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email required!")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required!")]
        public string Password { get; set; }
    }
}
