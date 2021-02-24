using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class StudentViewModel
    {
        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
       
        [Required]
        public string State { get; set; }
        
        [Required]
        public string Country { get; set; }

    }
}
