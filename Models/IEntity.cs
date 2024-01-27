using System;

namespace MVCKurumsalSiteProje.Models
{
    internal interface IEntity
    {
        int Id { get; set; }
        DateTime? CreateDate { get; set; }
    }
}
