using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Complaint_Management_System.Controllers
{
    public class BaseController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public int? UserID { get; set;}

        //public BaseController(UserManager<IdentityUser> userManager) 
        //{
        //    _userManager = userManager;

        //    var user = await _userManager.GetUserAsync(User);
        //    UserID = user != null ? user.Id : null;
        //}

        //private int? GetUserID() 
        //{
        //    var user = User..Identity.
        //    return null;
        //}

    }
}
