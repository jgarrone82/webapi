using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace webapi.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Effort { get; set; }

        [JsonIgnore]
        public virtual ICollection<Task>? Tasks { get; set; }
    }
}