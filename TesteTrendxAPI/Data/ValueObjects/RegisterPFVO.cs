using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Data.ValueObjects
{
    public class RegisterPFVO
    {
        public long id {  get; set; }
        [Required(ErrorMessage = "O Campo Name é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O Campo BirthDate é obrigatório")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "O Campo IncomeValue é obrigatório")]
        public decimal IncomeValue { get; set; }
        [Required(ErrorMessage = "O Campo CPF é obrigatório")]
        public string CPF {  get; set; }
    }
}
