using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePayrollMVC.Models.Common
{
    public class RegisterRequestModel
    {
        public int EmpId { get; set; }

        [Required]
        [StringLength(20,ErrorMessage ="Name max length is 20 characters")]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string SalaryId { get; set; }

        [Required]
        [DateRange("01/01/2000")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime StartDate { get; set; }

        public string Description { get; set; }
    }
}