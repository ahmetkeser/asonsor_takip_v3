using AsansorTakipV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsansorTakipV3.Controllers
{
    public class YapilanIsController : Controller
    {
        //
        // GET: /YapilanIs/
        HizmetBLL _hizmet = new HizmetBLL();
        YapilanIsBLL _Istakip = new YapilanIsBLL();
        MusteriBLL _musteri = new MusteriBLL();
        YapilanIsBLL _yapilanis = new YapilanIsBLL();
        public ActionResult Index()
        {

            return View(_hizmet.GetAll()); // Aktif İşler
        }
        public ActionResult Detay(int HizmetNo = 0)
        {
            ViewBag.Tut = HizmetNo;
            return View(_yapilanis.GetAll(f => f.Hizmet_Id == HizmetNo));
        }
        public ActionResult IsEkle(int Id = 0)
        {
            return View(_hizmet.GetById(Id));
        }
        [HttpPost]
        public ActionResult IsEkle(YapilanIs model)
        {
            // ViewBag.musteri = _musteri.GetById(Id);
            // ViewBag.yapilanis = _hizmet.GetById(Yapilan);
            _yapilanis.Insert(model);
            return RedirectToAction("Detay", "YapilanIs", new { HizmetNo = model.Hizmet_Id });
            // return View(_yapilanis.Get());
        }
    }
}
