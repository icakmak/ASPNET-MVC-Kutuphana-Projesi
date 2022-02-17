namespace Kutuphane.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Kutuphane.Data.Context>
    {
        public Configuration()
        {
            //Veri tabanını otomatik güncelleme için true yapıldı
            AutomaticMigrationsEnabled = true;
            //Tabloda veri olsa bile değişiklik yapılabilmesi için izin verildi
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Kutuphane.Data.Context";
        }

        protected override void Seed(Kutuphane.Data.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
