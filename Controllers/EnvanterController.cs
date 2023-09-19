using AsansorTakipV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsansorTakipV3.Controllers
{
    public class EnvanterController : Controller
    {
        //
        // GET: /Envanter/
        MarkaBLL _marka = new MarkaBLL();
        SinifBLL _sinif = new SinifBLL();
        HizmetBLL _hizmet = new HizmetBLL();
        public ActionResult Index()
        {
            return View(_sinif.GetAll());
        }
        public ActionResult Detay(int Id = 0)
        {
            ViewBag.Markalar = _marka.GetAll();
            return View(_sinif.GetById(Id));
        }
        [HttpPost]
        public ActionResult Detay(Sinif model)
        {
            _sinif.InsertOrUpdate(model, model.Id);
            return RedirectToAction("Index", "Envanter");
        }
        public ActionResult Sinif(int Id)
        {
            ViewBag._marka = _marka.GetById(Id);
            return View(_sinif.GetAll(f => f.Marka_Id == Id));
        }
        public ActionResult SinifDetay(int Id = 0)
        {
            return View(_sinif.GetById(Id));
        }
        [HttpPost]
        public ActionResult SinifDetay(Sinif model)
        {
            _sinif.InsertOrUpdate(model, model.Id);
            return RedirectToAction("Sinif", "Envanter");
        }
        public ActionResult DetaySil(int Id = 0)
        {
            var tut = _hizmet.GetAll(f => f.Sinif_Id == Id);
            foreach (var item in tut)
            {
                _hizmet.Delete(item.Id);
            }
            _sinif.Delete(Id);
            return RedirectToAction("index", "Envanter");
        }
    }
}
