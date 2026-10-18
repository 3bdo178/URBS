using System.ComponentModel.DataAnnotations;

namespace URBS.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        public Vehicle Vehicle { get; set; }
        public ICollection<Ride> DriverRides { get; set; }
        public ICollection<Ride> RiderRides { get; set; }
    }
}
