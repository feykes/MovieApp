using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name = "Email Adresiniz:")]
        [Required(ErrorMessage = "Email alanı gereklidir!")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Şifreniz:")]
        [Required(ErrorMessage = "Şifre alanınız gereklidir!")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Şifreniz en az 4 karakterli olmalıdır!")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
