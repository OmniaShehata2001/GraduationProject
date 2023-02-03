using GraduationProject.DatabaseContext;
using GraduationProject.GraduationProjectLogic;
using GraduationProject.User;
using GraduationProject.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GraduationProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly GraduationProjectContext _graduationProjectContext;
        private readonly UserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersController(GraduationProjectContext graduationProjectContext, UserService userService)
        {
            this._graduationProjectContext = graduationProjectContext;
            this._userService = userService;
        }
        public IActionResult Index()
        {             
            var newUserVm = new AddNewUserVM();
            return View(newUserVm);
        }


        [HttpPost]
        public async Task<IActionResult> AddUser(AddNewUserVM newUserVm)
        {
            var result = Users.Create(newUserVm);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("Validation Error", result.ErrorMessage);
                return View("Index", newUserVm);
            }

            await _graduationProjectContext.Users.AddAsync(result.Value);

            await _graduationProjectContext.SaveChangesAsync();

            _userService.LogInUser(result.Value.Id,result.Value.Name);


            return RedirectToAction("Index", "Home");
        }



    }
}
