using Kutuphane.Data.Model;
using Kutuphane.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class YazarController : Controller
    {
        UnitOfWork unitOfWork;
        public YazarController()
        {
            unitOfWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            var yazarlar = unitOfWork.GetRepository<Yazar>().GetAll();
            return View(yazarlar);
        }
        [HttpPost]
        public JsonResult EkleJson(string yzrAd)
        {
            Yazar yzr = new Yazar();
            yzr.Ad = yzrAd;
            var eklenenYzr = unitOfWork.GetRepository<Yazar>().Add(yzr);
            unitOfWork.SaveChanges();
            return Json(
                new
                {
                    Result = new
                    {
                        Id = eklenenYzr.Id,
                        Ad = eklenenYzr.Ad,

                    },
                    JsonRequestBehavior.AllowGet
                }
                );
        }
        [HttpPost]
        public JsonResult GuncelleJson(int yzrId, string yzrAd)
        {
            var yazar = unitOfWork.GetRepository<Yazar>().GetById(yzrId);
            yazar.Ad = yzrAd;
            var durum = unitOfWork.SaveChanges();
            if (durum > 0)
            {
                return Json(1);
            }
            return Json(0);
        }
        [HttpPost]
        public JsonResult SilJson(int yzrId)
        {
            unitOfWork.GetRepository<Yazar>().Delete(yzrId);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0)
            {
                return Json(1);
            }
            return Json(0);
        }
    }
}