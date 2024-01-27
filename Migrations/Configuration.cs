using System.Data.Entity.Migrations;
using System.Linq;

namespace MVCKurumsalSiteProje.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Data.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Data.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            // Bu metot veritabanı oluştuktan sonra tablolara kayıt eklemeyi sağlıyor örneğin varsayılan admin kullanıcısı oluşturma için.
            if (!context.Users.Any()) // eğer db de hiç bir kullanıcı yoksa
            {
                context.Users.Add(
                    new Models.User()
                    {
                        Email = "admin@mvckurumsal.net",
                        IsActive = true,
                        IsAdmin = true,
                        Name = "Admin",
                        Surname = "User",
                        Password = "Admin123"
                    });
                context.SaveChanges();
            }
        }
    }
}
