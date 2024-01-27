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
        // dbsetleri haz�rlad�ktan sonra �nce enable-migrations ile g��� aktif edip sonra update-database ile db yi olu�turuyoruz
        // veritaban� olu�tuktan sonra projeye add new scaffolded item men�s�nden ad� admin olan bir area ekliyoruz
    }
}