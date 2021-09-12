﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WesamTask.DAL.Entities
{
    [Table("Employee")]

    public class Employee
    {
        [Key]

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }
        
        public DateTime DateOfBirth { get; set; }

    }
}
