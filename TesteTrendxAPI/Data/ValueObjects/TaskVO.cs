using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Data.ValueObjects
{
    public class TaskVO
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "O Campo Título é obrigatório")]
        public string Title { get; set; }
        [Required(ErrorMessage = "O Campo Description é obrigatório")]
        public string Description { get; set; }
        [Required(ErrorMessage = "O Campo Completed é obrigatório")]
        public bool Completed{ get; set; }
    }
}
