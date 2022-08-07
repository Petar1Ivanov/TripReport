using System.ComponentModel.DataAnnotations;
using static TripReport.Data.DataConstants;
namespace TripReport.Data.Models
{
    public class Trip
    {
        public int Id { get; set; }

        public DateTime FromDate { get; set; }
             
        public int DurationId { get; set; }

        public Duration Duration { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string ContactPerson { get; set; }

        public int PersonCount { get; set; }

        public bool IsActive { get; set; }

        public int PaymentId { get; set; }

        public Payment Payment { get; set; }

        public string UserId { get; set; }       

    }

}
