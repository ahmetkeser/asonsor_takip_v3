using AsansorTakipV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsansorTakipV3.Controllers
{
    public class MarkalarController : Controller
    {
        //
        // GET: /Markalar/
        MarkaBLL _marka = new MarkaBLL();
        HizmetBLL _hizmet = new HizmetBLL();
        SinifBLL _sinif = new SinifBLL();
        public ActionResult Index()
        {
            return View(_marka.GetAll());
        }
        [HttpPost]
        public ActionResult Index(int Id)
        {
            return View(_marka.GetById(Id));
        }
        [HttpPost]
        public ActionResult Detay(Marka model)
        {
            _marka.InsertOrUpdate(model, model.Id);
            return RedirectToAction("Index", "Markalar");
        }
        public ActionResult Detay(int Id = 0)
        {
            return View(_marka.GetById(Id));
        }
        public ActionResult DetaySil(int Id = 0)
        {

            var tut1 = _sinif.GetAll(f => f.Marka_Id == Id);
            foreach (var item in tut1)
            {
                var tut2 = _hizmet.GetAll(f => f.Sinif_Id == item.Id);

                if (tut2 != null)
                {
                    foreach (var item2 in tut2)
                    {
                        _hizmet.Delete(item2.Id);
                    }
                }

                tut2 = null;
                _sinif.Delete(item.Id);
            }
            _marka.Delete(Id);

            return RedirectToAction("index", "Markalar");
        }
    }
}
