﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore_2020.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Возраст является обязательным")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя является обязательным")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия является обязательной")]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Отчество является обязательным")]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Должность является обязательной")]
        [Display(Name = "Должность")]
        public string Position { get; set; }
    }
}
