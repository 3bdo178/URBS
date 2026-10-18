using System.ComponentModel.DataAnnotations;

namespace URBS.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Required, Range(20,5000)]
        public decimal Amount { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int RideId { get; set; }
        public Ride Ride { get; set; }
    }
}
