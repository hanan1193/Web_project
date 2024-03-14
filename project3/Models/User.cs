using System.ComponentModel.DataAnnotations;

namespace project3.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? Password { get; set; }

        public string? Email { get; set; }
    }
}
