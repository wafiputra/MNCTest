using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MNCTest.Controllers
{
    public class HomeController : Controller
    {
        mnctestContext _context = new mnctestContext();
        public ActionResult Index()
        {
            var ListOfData = _context.citizens.ToList();
            return View(ListOfData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(citizen model) 
        {
            _context.citizens.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.citizens.Where(x => x.nik == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(citizen model)
        {
            var data = _context.citizens.Where(x => x.nik == model.nik).FirstOrDefault();
            if (data != null)
            {
                data.nama = model.nama;
                data.alamat = model.alamat;
                data.status = model.status;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var data = _context.citizens.Where(x => x.nik == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = _context.citizens.Where(x => x.nik == id).FirstOrDefault();
            _context.citizens.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Data Delete Successfully";
            return RedirectToAction("Index");
        }
        
    }
}