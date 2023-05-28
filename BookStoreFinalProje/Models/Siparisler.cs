using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookStoreFinalProje.Models;

[Table("Siparisler")]
public partial class Siparisler
{
    [Key]
    [Column("SiparisID")]
    public int SiparisId { get; set; }

    [Column("KullaniciID")]
    public int? KullaniciId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SiparisTarihi { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? ToplamFiyat { get; set; }

    [ForeignKey("KullaniciId")]
    [InverseProperty("Siparislers")]
    public virtual Kullanicilar? Kullanici { get; set; }

    [InverseProperty("Siparis")]
    public virtual ICollection<SiparisDetaylari> SiparisDetaylaris { get; set; } = new List<SiparisDetaylari>();
}
