using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookStoreFinalProje.Models;

[Table("SiparisDetaylari")]
public partial class SiparisDetaylari
{
    [Key]
    [Column("SiparisDetayID")]
    public int SiparisDetayId { get; set; }

    [Column("SiparisID")]
    public int? SiparisId { get; set; }

    [Column("KitapID")]
    public int? KitapId { get; set; }

    public int? Adet { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? BirimFiyat { get; set; }

    [ForeignKey("KitapId")]
    [InverseProperty("SiparisDetaylaris")]
    public virtual Kitaplar? Kitap { get; set; }

    [ForeignKey("SiparisId")]
    [InverseProperty("SiparisDetaylaris")]
    public virtual Siparisler? Siparis { get; set; }
}
