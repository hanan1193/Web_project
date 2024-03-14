using System.ComponentModel.DataAnnotations;

namespace project3.Models
{
    public class Car
    {
        [Key]
        
        public int CarId { get; set; }
        public string Type { get; set; } = string.Empty;
        public int? Model { get; set; }

        public string? Color { get; set; }
        public double? Price { get; set; }
        public int UserId { get; set; }
    }
}
