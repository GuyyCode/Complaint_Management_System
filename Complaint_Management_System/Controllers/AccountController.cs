
using Complaint_Management_System.Data;
using Complaint_Management_System.Models;
using Complaint_Management_System.Models.Entities;
using Complaint_Management_System.Models.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Complaint_Management_System.Controllers
{
    #region Account Controller
    [Authorize]
    public class AccountController : Controller
    {
        #region Properties
        private readonly CMSDataDbContext _cmsDataDbContext;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly  RoleManager<IdentityRole> _roleManager;
        #endregion

        #region Contsructor
        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, CMSDataDbContext cmsDataDbContext, ApplicationDbContext applicationDbContext) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _cmsDataDbContext = cmsDataDbContext;
            _applicationDbContext = applicationDbContext;
        }
        #endregion

        #region Action Methods
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewData["roles"] = _roleManager.Roles.Where(a => a.Name != "Admin").ToList();
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.StudentStaffNo, Email = model.Email };

                var result = await addNewUserRegistration(model).ConfigureAwait(false);
               
                if (result)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                   
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel { StudentNo = "" });
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.StudentNo, model.Password, model.RememberMe, lockoutOnFailure: false).ConfigureAwait(false);

            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }

            else 
            {
            }

            model.Success = false;

            return View(model);
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Account", "Login");
        }
        

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<bool> addNewUserRegistration(RegisterViewModel model)
        {
            try
            {
                var role = _roleManager.FindByIdAsync(model.UserRole).Result;

                var user = new IdentityUser { UserName = model.StudentStaffNo, Email = model.Email };

                var result = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(false);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, role.Name);

                    bool addedProfile = AddNewUserProfile(model);

                    return addedProfile;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AddNewUserProfile(RegisterViewModel model)
        {
            try
            {
                var _user = _applicationDbContext.Users.Where(p => p.UserName == model.StudentStaffNo).SingleOrDefault();

                if (_user != null)
                {
                    var _newUserProfile = new UserProfile
                    {
                        UserId = _user.Id,
                        FullName = model.FullName,
                        Faculty = GetFaculty(model.FacultyID),
                        UserType = model.UserRole,
                        StaffStudentNo = model.StudentStaffNo
                    };

                    _cmsDataDbContext.UserProfiles.Add(_newUserProfile);

                    _cmsDataDbContext.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Faculty GetFaculty(short title)
        {
            switch (title)
            {
                case 1:
                    return Faculty.AccountingAndInformatics;
                case 2:
                    return Faculty.AppliedSciences;
                case 3:
                    return Faculty.ArtsAndDesign;
                case 4:
                    return Faculty.EngineeringAndBuiltEnvironment;
                case 5:
                    return Faculty.HealthSciences;
                case 6:
                    return Faculty.ManagementSciences;
            }

            return Faculty.None;
        }
        #endregion
    }
    #endregion
}
