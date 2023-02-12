using GraduationProject.User;

namespace GraduationProject.Controllers
{
    public class ScanController
    {
        private readonly UserService _userService;

        public ScanController(UserService userService)
        {
            this._userService = userService;
        }
    }

}
