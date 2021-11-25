﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Complaint_Management_System.Models.Entities;

namespace Complaint_Management_System.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: AnnouncementController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AnnouncementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AnnouncementController/Create
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewAnnouncement(Announcement model)
        {
            try
            {
                return RedirectToAction("");
            }
            catch
            {
                return View();
            }
        }



        // POST: AnnouncementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnnouncementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnnouncementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnnouncementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnnouncementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}