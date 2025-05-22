using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Models
{
    public class RegistrationForm
    {
        [Required(ErrorMessage ="Full Name is required!")]
        [StringLength(100, MinimumLength =3, ErrorMessage ="Name Must be at least 3 character")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Email is required!")]
        [EmailAddress(ErrorMessage ="Enter a valid Email!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is required!")]
        [StringLength(100, MinimumLength =6, ErrorMessage ="Password must be at least 6 character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
