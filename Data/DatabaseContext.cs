using MVCKurumsalSiteProje.Models;
using System.Data.Entity;

namespace MVCKurumsalSiteProje.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<User> Users { get; set; }
        // dbsetleri hazýrladýktan sonra önce enable-migrations ile göçü aktif edip sonra update-database ile db yi oluþturuyoruz
        // veritabaný oluþtuktan sonra projeye add new scaffolded item menüsünden adý admin olan bir area ekliyoruz
    }
}