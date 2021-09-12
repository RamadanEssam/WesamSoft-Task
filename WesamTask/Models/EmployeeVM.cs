using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WesamTask.Models
{
    public class EmployeeVM
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Enter First Name"), MaxLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter Last Name"), MaxLength(100)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter contact"), MaxLength(20)]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Enter your Email"), MaxLength(128)]
        public string Email { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }


    }
}
