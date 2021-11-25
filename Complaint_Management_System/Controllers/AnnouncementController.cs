using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Complaint_Management_System.Models.Entities;
using Complaint_Management_System.Data;

namespace Complaint_Management_System.Controllers
{
    public class AnnouncementController : BaseController
    {
        private CMSDataDbContext _cmsDataDbContext;

        public AnnouncementController(CMSDataDbContext cmsDataDbContext)
        {
            _cmsDataDbContext = cmsDataDbContext;
        }

        public ActionResult GetStaffAnnouncements(string StaffID) 
        {
            return View(GetAnnouncements(StaffID));
        }

        private List<Announcement> GetAnnouncements(string StaffID) 
        {
            var toReturn = new List<Announcement>();

            toReturn = _cmsDataDbContext.Announcements.Where(a => a.StaffID == StaffID).ToList();

            return toReturn;
        }
        // GET: AnnouncementController
        public ActionResult NewAnnouncement()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewAnnouncement(Announcement model)
        {
            try
            {
                //save stuff from form to database
                var _complaint = new Announcement { Announcement_Date = DateTime.Now, Announcement_Description = model.Announcement_Description, StaffID = User.Identity.Name };

                return RedirectToAction("", "");
                //return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        }
    }

