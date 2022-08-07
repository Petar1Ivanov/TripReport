using System.ComponentModel.DataAnnotations;

namespace TripReport.Models.Trips
{
    public class TripAllViewModel
    {
        [Display(Name = "Начало")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}",
               ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; init; }
        
        [Display(Name = "Време")]
        public string Duration { get; init; }

        [Display(Name = "Клиент заявил")]
        public string CustomerName { get; init; }

        [Display(Name = "Лице за контакт и телефон")]
        public string ContactPerson { get; init; }

        [Display(Name = "Брой лица")]
        public int PersonCount { get; init; }

        public bool IsActive { get; init; }

        [Display(Name = "Начин на плащане")]
        public string Payment { get; init; }

        
    }
}
