using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewDiplom.Models
{
    public class Position
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Обязательное для заполнения*")]
        public string Position_name { get; set; }

        public string View => $"{Position_name}";

        public ICollection<Plurality> Plurality { get; set; }
        public Position()
        {
            Plurality = new List<Plurality>();
        }
    }
}
