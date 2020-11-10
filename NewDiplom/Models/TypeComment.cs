using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewDiplom.Models
{
    public class TypeComment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Обязательное для заполнения*")]
        [StringLength(30)]
        public string Name_comment { get; set; }

        public ICollection<TaskComment> TaskComments { get; set; }
        public TypeComment()
        {
            TaskComments = new List<TaskComment>();
        }
    }
}
