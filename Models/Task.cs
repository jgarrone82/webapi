using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class Task
    {
        public Guid TaskId { get; set; }
        public Guid CategoryId { get; set;}
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Priority PriorityTask { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual Category? Category { get; set; }

        [NotMapped]
        public string? Resume { get; set; }

    }
}