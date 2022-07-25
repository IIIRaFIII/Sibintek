using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Задача не задана")]
        [DisplayName("Задача")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Приоритет не задан")]
        [DisplayName("Приоритет")]
        public int Priority { get; set; }

        [Required(ErrorMessage = "Дата окончания не задана")]
        [DisplayName("Дата окончания")]
        public DateTime? Date { get; set; }

        public bool Status { get; set; }

        [Display(Name = "ФИО исполнителя")]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

    }
}
