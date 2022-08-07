using Microsoft.AspNetCore.Mvc;
using TripReport.Data;
using TripReport.Data.Models;
using TripReport.Models.Trips;

namespace TripReport.Controllers
{
    public class TripsController : Controller
    {
        private readonly TripDbContext data;

        public TripsController(TripDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add() => View(new AddTripFormModel
        {
            Payments = this.Payments(),
            Durations = this.Durations(),
        });

        [HttpPost]
        public IActionResult Add(AddTripFormModel trip)
        {
            if (!this.data.Payment.Any(x => x.Id == trip.PaymentId))
            {
                this.ModelState.AddModelError(nameof(trip.PaymentId), "Въведения вид плащaне е невалиден");
            }

            if (!this.data.Duration.Any(x => x.Id == trip.DurationId))
            {
                this.ModelState.AddModelError(nameof(trip.DurationId), "Въведеното времетраене не е невалиден");
            }
           

            bool x = ModelState.IsValid;
            if (!ModelState.IsValid)
            {
                trip.Payments = this.Payments();
                trip.Durations = this.Durations();
                return View(trip);
            }

        

              var tripData = new Trip
              {
                  FromDate = trip.FromDate,        
                  DurationId = trip.DurationId,
                  CustomerName = trip.CustomerName,
                  ContactPerson = trip.ContactPerson,
                  PersonCount = trip.PersonCount,
                  IsActive = true,
                  PaymentId = trip.PaymentId,
                  UserId="1111"
                  
                 
              };
            
            this.data.Add(tripData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        private IEnumerable<TripPaymentViewModel> Payments() =>
            data.Payment.Select(x => new TripPaymentViewModel
            {
                Name = x.Name,
                Id = x.Id,
            }).ToList();

        private IEnumerable<TripDurationViewModel> Durations() =>
            data.Duration.Select(x => new TripDurationViewModel
            {
                Name = x.Name,
                Id = x.Id,
            }).ToList();
        
    }

}
