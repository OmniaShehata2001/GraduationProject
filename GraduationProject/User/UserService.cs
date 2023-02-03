using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace GraduationProject.User
{
    public class UserService
    {
        public bool IsAuthenticated { get; set; } = false;
        public int? UserId { get; set; } = null;
        public string UserName { get; set; } = string.Empty;

        public UserService()
        {

        }


        public void LogInUser(int id,string name)
        {
            UserId = id;
            IsAuthenticated = true;
            UserName = name;
        }


        public bool UserIsLogin()
        {
            return IsAuthenticated;
        }


        public int? GetUserId()
        {
            return UserId;
        }

        internal void LogOutUser()
        {
            IsAuthenticated = false;
            UserId = null;
        }
    }
}
