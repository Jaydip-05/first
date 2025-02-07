using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace first.Models
{
    public class StudentdDTO
    {
        [ValidateNever]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string StudentName { get; set; }
        [EmailAddress(ErrorMessage = "Email chukicha aahe ") ]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public DateOnly Dob { get; set; }
       
    }
}
