using Complaint_Management_System.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Complaint_Management_System.Controllers
{
    public class ComplaintResponseController : Controller
    {
        // GET: ComplaintResponseController1


        public ActionResult Index(int ComplaintID)
        {
            var complaint = new Complaint { ComplaintID = ComplaintID };
            return View(complaint);
        }

        // GET: ComplaintResponseController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComplaintResponseController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComplaintResponseController1/Create
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

        // GET: ComplaintResponseController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComplaintResponseController1/Edit/5
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

        // GET: ComplaintResponseController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComplaintResponseController1/Delete/5
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
