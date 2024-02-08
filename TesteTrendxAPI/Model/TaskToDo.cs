using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ToDoListAPI.Model.Base;

namespace ToDoListAPI.Model
{
    [Table("tasksToDo")]
    public class TaskToDo : BaseEntity
    {
        [Column("title")]
        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Column("Description")]
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Column("Completed")]
        [Required]
        public bool Completed { get; set; }
    }
}
