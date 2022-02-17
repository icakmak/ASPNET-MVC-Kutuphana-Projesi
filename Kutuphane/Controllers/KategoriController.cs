using Kutuphane.Data;
using Kutuphane.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        public ActionResult Index()
        {
            Context context = new Context(); //DB bağlantısı için kullanılıyor

            /*
             Kitap için Kategori ekleyebilmek adına böyle bir yol izlendi daha sonra View üzerinden kitap ekleme 
            yapıldığında kategori seçimi yapılacağı için bu alanlara gerek kalmayacak
             */
            List<int> katagoriIds = new List<int>();
            katagoriIds.Add(1);
            katagoriIds.Add(2);

            List<Kategori> kategoriler = new List<Kategori>();
            foreach (var ktgId in katagoriIds)
            {
                var ktg = context.Kategoriler.FirstOrDefault(x => x.Id == ktgId);
                kategoriler.Add(ktg);
            }

            /*
             Kitap Modelinden yeni bir Ktiap nesnesi türetiliyor.
            VE bu nesne içindeki gerekli alanlara veriler dolduruluyor
             */
            Kitap kitap = new Kitap() { 
                Ad="Ay Yıldız",
                Adet=100,
                EklenmeTarihi=DateTime.Now,
                SiraNo="1",
                YazarId=1,
                Kategoriler=kategoriler
            };

            //Bağlantı ile Kitaplar tablosuna oluşturulan nesne verileri ekleniyor
            context.Kitaplar.Add(kitap);

            //Eklenme işlemi yapıldıktan sonra kaydetme işlemi gerçekleştiriliyor.
            context.SaveChanges();
            return View();
        }
    }
}