using System.ComponentModel.DataAnnotations;
using TripReport.Areas;
using static TripReport.Data.DataConstants;

namespace TripReport.Models.Trips
{
    public class AddTripFormModel
    {
        [Display(Name = "Начало")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy HH:mm}",
               ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }

        [Display(Name = "Време")]
        public int DurationId { get; set; }

        [Display(Name = "Клиент заявил")]
        [StringLength(MaxNameLength, MinimumLength = 3, ErrorMessage = "Името на клиента трябва да е от {2} до {1} символа")]
        public string CustomerName { get; set; }

        [Display(Name = "Лице за контакт и телефон")]
        [StringLength(MaxNameLength, MinimumLength = 3, ErrorMessage = "Името на лице за контакт трябва да е от {1} до {0} символа")]
        public string ContactPerson { get; set; }

        [Display(Name = "Брой лица")]
        [Range(1, 60, ErrorMessage = "Броят пътуващи трябва да е от {1} до {2}")]
        public int PersonCount { get; set; }

        public bool IsActive { get; set; }

        [Display(Name = "Начин на плащане")]        
        public int PaymentId { get; init; }

        public IEnumerable<TripPaymentViewModel>? Payments { get; set; }

        public IEnumerable<TripDurationViewModel>? Durations { get; set; }

    }
}
