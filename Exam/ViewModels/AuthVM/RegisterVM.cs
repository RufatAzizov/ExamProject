using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Exam.ViewModels.AuthVM
{
    public class RegisterVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
