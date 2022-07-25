using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "ФИО не задано")]
        [DisplayName("ФИО")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Дата рождения не задана")]
        [DataType(DataType.Date)]
        [DisplayName("Дата рождения")]
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage = "Пол не задан")]
        [DisplayName("Пол")]
        public char Gender { get; set; }

        [DisplayName("Начало рабочего дня")]
        [DataType(DataType.Time)]
        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [Required(ErrorMessage = "Кол-во Рабочих дней не задано")]
        [DisplayName("Кол-во Рабочих дней")]
        public string WorkingDays { get; set; }

    }
}
