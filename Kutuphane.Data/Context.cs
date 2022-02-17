using Kutuphane.Data.Migrations;
using Kutuphane.Data.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Kutuphane.Data
{
    public class Context:DbContext
    {
        public Context() : base("Context")
        {
            //Veri tabanı var ise güncelleme yok ise Oluşturma işlemi için bu kod parçacığı eklendi
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>("Context"));
        }
        /*
         Kutuphane programı için Db oluşturuluyor
        Oluşturulması istenen db Kutuphane.Data.Model içinde tanımlanan sınıflardan çekiliyor
        KDM içinde belirtilen özelliklerde/tipde ki metodlar oluşturulan Kutuphane.Data içine çekiliyor
        Context Sınıfı içinde DbSet ile Tablo İsimleri oluşturulup MSSQL de DB 'nin hazırlanması Sağlanıyor
         */

        /*
         Tablo isimleri KDM içinde tanımlanan Sınıflardan Gelmektedir.DB'de tablo isimlerdirmesi yapılmak istenirse Sınıf isimleri ona göre şekillendirilmeli
        örnek olarak KDM içinde bulunan Kategor.cs dosyasında sınıflandırma ismi Kategori olarak ayarlanmıştır.Bunun yerine Sınıf oluşturulurken TBL_Kategori olarak sınıf ismi
        yazılırsa DB 'de TBL_Kategori isminde bir tablo oluşturulur.
         */
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<OduncKitap> OduncKitaplar { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //db'de tablo sonlarında bulunan s takısı kaldırma için yazıldı.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
