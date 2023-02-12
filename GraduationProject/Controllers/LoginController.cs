using GraduationProject.DatabaseContext;
using GraduationProject.GraduationProjectLogic;
using GraduationProject.User;
using GraduationProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace GraduationProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserService userService;
        private readonly GraduationProjectContext graduationProjectContext;

        public LoginController(UserService userService,GraduationProjectContext graduationProjectContext)
        {
            this.userService = userService;
            this.graduationProjectContext = graduationProjectContext;
        }
        public IActionResult Index()
        {
            Loginviewmodel loginviewmodel = new Loginviewmodel();
            return View(loginviewmodel);
        }


        [HttpPost]
        public async Task<IActionResult> Login (Loginviewmodel loginviewmodel)
        {
            var userNeedToCheck = await graduationProjectContext.Users
                .FirstOrDefaultAsync(x=>x.Name == loginviewmodel.Username);
            if (userNeedToCheck is null) 
            {
                ModelState.AddModelError("Validation Error", "User Not Found");
                return View("Index",loginviewmodel);
            }
            if (loginviewmodel.Password != userNeedToCheck.Password) 
            {
                ModelState.AddModelError("Validation Error", "The Password Incorrect");
                return View("Index",loginviewmodel);
            }
            userService.LogInUser(userNeedToCheck.Id, userNeedToCheck.Name);


            return RedirectToAction("Index", "Home");
        }
    }
}
