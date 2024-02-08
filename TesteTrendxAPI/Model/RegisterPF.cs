using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoListAPI.Model.Base;

namespace ToDoListAPI.Model
{
    [Table("RegisterPF")]
    public class RegisterPF : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Column("birthDate")]
        [Required]
        public DateTime BIrthDate { get; set; }

        [Column("incomeValue")]
        [Required]
        public decimal IncomeValue { get; set; }

        [Column("cpf")]
        [Required]
        [StringLength(11)]
        public string Cpf {  get; set; }
    }
}
