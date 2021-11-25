using Complaint_Management_System.Data;
using Complaint_Management_System.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Complaint_Management_System.Controllers
{
    public class ComplainController : BaseController
    {
        public CMSDataDbContext  _cmsDataDbContext  { get; set; }
        public ComplainController(CMSDataDbContext cmsDataDbContext) 
        {
            _cmsDataDbContext = cmsDataDbContext;
        }
        
        //Get
        public ActionResult NewComplaint()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewComplaint(Complaint model)
        {
            try
            {
                //save stuff from form to database
                var _complaint = new Complaint { Complaint_Date = DateTime.Now, Description = model.Description,  StudentNo = User.Identity.Name };
             
                return RedirectToAction("","");
                //return View();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
