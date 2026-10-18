using System.ComponentModel.DataAnnotations;

namespace URBS.Models
{
    public class Rating
    {
        public int Id { get; set; }
        [Range(1,5)]
        public int Score { get; set; }
        [MaxLength(250)]
        public string Comment { get; set; }
        public int RideId { get; set; }
        public Ride Ride { get; set; }
    }
}
