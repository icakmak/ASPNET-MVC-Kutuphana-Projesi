using Kutuphane.Data.Model;
using Kutuphane.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class KitapController : Controller
    {
        UnitOfWork unitOfWork;
        public KitapController()
        {
            unitOfWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            var kitaplar = unitOfWork.GetRepository<Kitap>().GetAll();
            return View(kitaplar);
        }
        public ActionResult Ekle()
        {
            ViewBag.Kategoriler = unitOfWork.GetRepository<Kategori>().GetAll();
            ViewBag.Yazarlar = unitOfWork.GetRepository<Yazar>().GetAll();
            return View();
        }
        [HttpPost]
        public JsonResult EkleJson(string[] kategoriler,string yazar,string kitapAdi,string kitapAdet,string kitapSira)
        {
            
            List<Kategori> k = new List<Kategori>();
            foreach (var kId in kategoriler)
            {
                var gID = Convert.ToInt32(kId);
                var kategori = unitOfWork.GetRepository<Kategori>().GetById(gID);
                k.Add(kategori);
            }
            Kitap kitap = new Kitap();
            kitap.Ad = kitapAdi;
            kitap.Adet = Convert.ToInt32(kitapAdet);
            kitap.SiraNo = kitapSira;
            kitap.YazarId = Convert.ToInt32(yazar);
            kitap.Kategoriler = k;
            kitap.EklenmeTarihi = DateTime.Now;
            unitOfWork.GetRepository<Kitap>().Add(kitap);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0)
            {
                return Json(1);
            }
            return Json(0);
           
        }
    }
}