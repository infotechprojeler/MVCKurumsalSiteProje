using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCKurumsalSiteProje.Models
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adı"), StringLength(50), Required]
        public string Name { get; set; }
        [Display(Name = "Açıklama"), StringLength(500)]
        public string Description { get; set; }
        [Display(Name = "Resim"), StringLength(100)]
        public string Image { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Anasayfada Göster")]
        public bool IsHome { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)] // ScaffoldColumn(false) özelliği oluşturulacak view ekranlarında bu alanı oluşturma demektir.
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public virtual List<Post> Posts { get; set; }
    }
}