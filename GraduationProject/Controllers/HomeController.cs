using GraduationProject.User;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService _userService;

        public HomeController(UserService userService)
        {
            this._userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            _userService.LogOutUser();
            return View("Index", "Home");
        }
    }
}
