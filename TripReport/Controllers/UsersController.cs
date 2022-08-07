using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TripReport.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> singInManager;

        public UsersController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> singInManager)
        {
            this.userManager = userManager;
            this.singInManager = singInManager;
        }
        public IActionResult Register()=>View();
    }
}
