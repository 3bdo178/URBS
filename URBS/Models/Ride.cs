using System.ComponentModel.DataAnnotations;

namespace URBS.Models
{
    public class Ride
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string PickUpLocation { get; set; }
        [Required, MaxLength(150)]
        public string DropOffLocation { get; set; }
        [Required, Range(20,5000)]
        public decimal Fare { get; set; }
        public int? DriverId { get; set; }
        [Required]
        public int RiderId { get; set; }
        [Required]
        public string Status { get; set; }
        public User? Driver { get; set; }
        public User Rider { get; set; }
        public Rating? Rating { get; set; }
        public Payment? Payment { get; set; }
    }
}
