using System.ComponentModel.DataAnnotations;

namespace FinalExp.MVC.Areas.manage.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string Username { get; set; }
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
