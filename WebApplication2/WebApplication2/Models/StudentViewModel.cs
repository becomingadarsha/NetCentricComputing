using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class StudentViewModel 
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public String FullName { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Phone { get; set; }

    }
}
