using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace server.Model
{
    public class SurveyOne
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Address { get; set; }  = string.Empty;

        [Required]
        [StringLength(100)]
        public string County { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string State { get; set; } = string.Empty;

        [Required]
        [StringLength(5)]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "ZipCode must be exactly 5 digits.")]
        public string ZipCode { get; set; } = string.Empty;


    }
}