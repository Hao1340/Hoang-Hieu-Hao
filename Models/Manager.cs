
using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class Manager 
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
