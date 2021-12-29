using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Model
{
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email required!")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required!")]
        [MinLength(4, ErrorMessage = "Password must be at least 4 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
