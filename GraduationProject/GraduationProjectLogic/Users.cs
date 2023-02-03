using GraduationProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.GraduationProjectLogic
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }



        public static Result<Users> Create(AddNewUserVM addNewUserVM) 
        {
            if(string.IsNullOrEmpty(addNewUserVM.Password)) 
            {
                return Result<Users>.Failure("Password InCorrect");
            }

            var user = new Users 
            {
                Mail= addNewUserVM.Mail,
                Phone= addNewUserVM.Phone,
                Password= addNewUserVM.Password,
                Name= addNewUserVM.Name,
            };

            
            return Result<Users>.Success(user);
        }
    }
}
