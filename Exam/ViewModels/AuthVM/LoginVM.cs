using System.ComponentModel.DataAnnotations;

namespace Exam.ViewModels.AuthVM
{
    public class LoginVM
    {
        public string UserNameOrEmail { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public bool isRemember { get; set; }


    }
}
