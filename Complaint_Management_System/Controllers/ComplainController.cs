using Complaint_Management_System.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Complaint_Management_System.Controllers
{
    public class ComplainController : Controller
    {
        // GET: ComplainController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ComplainController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComplainController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComplainController/Create
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

        // GET: ComplainController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComplainController/Edit/5



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewComplaint(Complaint model)
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

        // GET: ComplainController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComplainController/Delete/5
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
