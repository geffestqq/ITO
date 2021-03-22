using Diplom.Models;
using System.ComponentModel.DataAnnotations;

namespace Diplom.ViewModels
{
    public class AccountViewModel
    {
        public string Id { get; set; }


        [Required(ErrorMessage = "Обязательное для заполнения*")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Обязательное для заполнения*")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Phone]
        [Display(Name = "Phone")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Обязательное для заполнения*")]
        [StringLength(100, ErrorMessage = "Минимальная длина 6 символов", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Обязательное для заполнения*")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        public int? PluralityId { get; set; }

        public string PluralityView { get; set; }
    }
}
