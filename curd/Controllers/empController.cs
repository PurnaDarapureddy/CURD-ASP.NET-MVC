using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using curd.Models;

namespace curd.Controllers
{
    public class empController : Controller
    {
        // GET: emp
        public ActionResult addemp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addemp(addemp ad)
        {
            if (ModelState.IsValid)
            {
                repo re = new repo();
                re.addemp(ad);
                return RedirectToAction("getemp");
            }
            return View();
        }
        public ActionResult getemp()
        {
            repo re = new repo();
            ModelState.Clear();
            return View(re.getemp());
        }
        public ActionResult updateemp(int id)
        {
            repo re = new repo();
            return View(re.getemp().Find(e => e.empid == id));

        }
        [HttpPost]
        public ActionResult updateemp(addemp ad)
        {
            if(ModelState.IsValid)
            {
                repo re = new repo();
                re.updateemp(ad);
                return RedirectToAction("getemp");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                repo re = new repo();
                re.deleteemp(id);
                return RedirectToAction("getemp");
            }
            return View();
        }
    }
}