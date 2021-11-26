using Complaint_Management_System.Data;
using Complaint_Management_System.Models;
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
        private List<Complaint> GetComplaints(string StudentNo)
        {
            var toReturn = new List<Complaint>();

            toReturn = _cmsDataDbContext.Complaints.Where(a => a.StudentNo == StudentNo).ToList();

            return toReturn;
        }

        private complaintsViewmodel GetStudentComplaints(string StudentNo) 
        {
            var toReturn = new complaintsViewmodel
            {
                Complaints = GetComplaints(StudentNo)
            };

            return toReturn;
        }

        public ActionResult Index()
        {
            return View(GetStudentComplaints(User.Identity.Name));
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

                _cmsDataDbContext.Complaints.Add(_complaint);
                _cmsDataDbContext.SaveChanges();

                return RedirectToAction("Index","Complain");
                //return View();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
