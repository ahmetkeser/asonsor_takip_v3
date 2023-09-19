using AsansorTakipV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsansorTakipV3.Controllers
{
    public class MusterilerController : Controller
    {
        //
        // GET: /Musteriler/
        MusteriBLL _musteri = new MusteriBLL();
        HizmetBLL _hizmet = new HizmetBLL();
        MarkaBLL _marka = new MarkaBLL();
        SinifBLL _sinif = new SinifBLL();
        public ActionResult Index()
        {
            return View(_musteri.Get());
        }

        [HttpPost]
        public ActionResult Detay(Musteri model)
        {
            _musteri.InsertOrUpdate(model, model.Id);
            return RedirectToAction("Index", "Musteriler");
        }
        public ActionResult Detay(int Id = 0)
        {
            return View(_musteri.GetById(Id));
        }
        public ActionResult Hizmet(int Id = 0)
        {

            return View(_musteri.GetById(Id));
        }
        public ActionResult HizmetEkle(int Id = 0)
        {
            ViewBag.Sinif = _sinif.GetAll();
            return View(_musteri.GetById(Id));
        }
        [HttpPost]
        public ActionResult HizmetEkle(Hizmet model)
        {
            _hizmet.Insert(model);
            return RedirectToAction("Hizmet", "Musteriler", new { Id = model.Musteri_Id });
        }
        public ActionResult HizmetDetay(int Id = 0)
        {
            ViewBag.tut = _musteri.GetById(Id);
            ViewBag.Sinif = _sinif.GetAll();
            return View(_hizmet.GetById(Id));
        }
        [HttpPost]
        public ActionResult HizmetDetay(Hizmet model)
        {

            _hizmet.InsertOrUpdate(model, model.Id);
            return RedirectToAction("Hizmet", "Musteriler", new { Id = model.Musteri_Id });
        }
        public ActionResult Sill(int Id = 0)
        {
            var numara = _musteri.GetById(Id);

            foreach (var item in numara.Hizmet)
            {
                _hizmet.Delete(item.Id);
            }

            using (MusteriBLL _musterisil = new MusteriBLL())
            {
                _musterisil.Delete(Id);
            }


            return RedirectToAction("Index", "Musteriler");
        }
        public ActionResult Hizmetsil(int Id)
        {

            var tut = _hizmet.GetById(Id);
            int gel = tut.Musteri_Id;
            _hizmet.Delete(Id);
            Id = gel;
            return RedirectToAction("Hizmet", "Musteriler", new { Id });
        }
    }
}
