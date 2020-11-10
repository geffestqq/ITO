using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewDiplom.Models
{
    public class Account
    {   
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Обязательное для заполнения*")]
        [StringLength(30)]
        public string Login  { get; set; }
        [Required(ErrorMessage = "Обязательное для заполнения*")]
        [StringLength(30)]

        public string Password { get; set; }
        [Required(ErrorMessage = "Обязательное для заполнения*")]
        public string Date_Create { get; set; }
        [Required(ErrorMessage = "Обязательное для заполнения*")]
        [StringLength(16)]
        public string Phone_Number { get; set; }
        [Required(ErrorMessage = "Обязательное для заполнения*")]
        [StringLength(30)]
        public string Email { get; set; }
        public int RightsId { get; set; }
        public Right Rights { get; set; }

        public int PluralityId { get; set; }
        public Plurality Plurality { get; set; }


    }
}
