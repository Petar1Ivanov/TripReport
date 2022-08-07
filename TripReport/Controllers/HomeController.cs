using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TripReport.Data;
using TripReport.Data.Models;
using TripReport.Models;
using TripReport.Models.Trips;

namespace TripReport.Controllers
{
    public class HomeController : Controller
    {
        private readonly TripDbContext data;

        public HomeController(TripDbContext data)
        {
            this.data = data;
        }

        //private readonly ILogger<HomeController> _logger;


        //public HomeController(ILogger<HomeController> logger)
       // {
        //    _logger = logger;
       // }

        public IActionResult Index()
        {
            var trips = this.data.Trip
                .OrderByDescending(x=>x.FromDate)
                .Where(x=>x.FromDate>DateTime.Now)
                .Select(x => new TripAllViewModel
                {
                    FromDate= x.FromDate,
                    Duration= x.Duration.Name,
                    CustomerName= x.CustomerName,
                    ContactPerson= x.ContactPerson,
                    PersonCount= x.PersonCount,
                    Payment=x.Payment.Name,
                    IsActive=x.IsActive,
                }
                ).ToList();
            return View(trips);
        }     

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
         //   return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
      
    }
}