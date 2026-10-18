using System.ComponentModel.DataAnnotations;

namespace URBS.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Model { get; set; }
        [Required, MaxLength(20)]
        public string PlateNumber { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int DriverId { get; set; }
        public User Driver { get; set; }

    }
}
