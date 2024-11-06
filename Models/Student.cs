using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models

{
    public class Student
    {
        public int Id { get; set; }
        public required string Name { get; set; } 
        [Required]
        [EmailAddress]
        
        public required string Email { get; set; } 
        public int CategoryId { get; set; }
        public Category? Category { get; set; } 
       
    }


}
