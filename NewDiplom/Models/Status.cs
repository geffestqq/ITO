﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewDiplom.Models
{
    public class Status
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Обязательное для заполнения*")]
        [StringLength(30)]
        public string Status_name { get; set; }

        public ICollection<TaskDistribution> TaskDistributions { get; set; }
        public ICollection<Zadachi> Zadachis { get; set; }
        public Status()
        {
            TaskDistributions = new List<TaskDistribution>();
            Zadachis = new List<Zadachi>();
        }
    }
}
