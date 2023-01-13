using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities.ViewModel
{
    public class UserRegisterViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Adı alanı gereklidir!")]
        [Display(Name = "Adı:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyadı alanı gereklidir!")]
        [Display(Name = "Soyadı:")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Kullanıcı isminiz gereklidir!")]
        [Display(Name = "Kullanıcı Adı:")]
        public string UserName { get; set; }

        [Display(Name = "Telefon Numarası:")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email adresiniz gereklidir!")]
        [Display(Name = "Email Adresiniz:")]
        [EmailAddress(ErrorMessage = "Email adresiniz doğru formatta değil!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifreniz gereklidir!")]
        [Display(Name = "Şifre:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Doğum Tarihi:")]
        [DataType(DataType.Date)]
        public DateTime? BirthDay { get; set; }


        [Display(Name = "Şehir:")]
        public string City { get; set; }

    }
}
