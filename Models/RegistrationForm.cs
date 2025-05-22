using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Models
{
    public class RegistrationForm
    {
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
