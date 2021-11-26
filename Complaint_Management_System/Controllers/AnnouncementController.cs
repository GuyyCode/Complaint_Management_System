using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Complaint_Management_System.Models.Entities;
using Complaint_Management_System.Data;
using Complaint_Management_System.Models;

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

        private AnnouncementViewmodel GetStaffAnnouncement(string StaffID)
        {
            var toReturn = new AnnouncementViewmodel
            {
                announcements = GetAnnouncements(StaffID)
            };

            return toReturn;
        }

        public ActionResult Index()
        {
            return View(GetStaffAnnouncement(User.Identity.Name));
        }

        // GET: AnnouncementController
        public ActionResult NewAnnouncement()
        {
            return View("Announcements");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewAnnouncement(Announcement model)
        {
            try
            {
                //save stuff from form to database
                var announcement = new Announcement { Announcement_Date = DateTime.Now, Announcement_Description = model.Announcement_Description, StaffID = User.Identity.Name };
                _cmsDataDbContext.Announcements.Add(announcement);
                _cmsDataDbContext.SaveChanges();

                return RedirectToAction("Index", "Announcement");
                //return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        }
    }

