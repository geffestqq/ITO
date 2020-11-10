using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewDiplom.Models
{
    public class TaskDistribution
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное для заполнения*"), StringLength(11)]
        public string Time_Distribution { get; set; }

        [Required(ErrorMessage = "Обязательное для заполнения*"), StringLength(11)]
        public string Date_Distribution { get; set; }

        [Required(ErrorMessage = "Обязательное для заполнения*"), StringLength(10)]
        public string Period_Distribution { get; set; }

        public int PluralityId { get; set; }
        public Plurality Plurality { get; set; }

// Эта строка не нужна , автоматически создаться эта колонкак как FK
        public int ZadachiId { get; set; }
        public Zadachi Zadachi { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public string View => String.Format("{0} {1} {2} {3} {4}",

                    Zadachi == null ? String.Empty : Zadachi.Task_Name,

                    Time_Distribution,

                    Date_Distribution,

                    Period_Distribution,

                    Plurality == null ? String.Empty : Plurality.View);


        public ICollection<TaskComment> TaskComments { get; set; }
        public ICollection<FileTask> FileTasks { get; set; }
        public TaskDistribution()
        {
            TaskComments = new List<TaskComment>();
            FileTasks = new List<FileTask>();
        }

    }
}
