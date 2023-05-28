using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookStoreFinalProje.Models;

[Table("Sepet")]
public partial class Sepet
{
    [Key]
    [Column("SepetID")]
    public int SepetId { get; set; }

    [Column("KullaniciID")]
    public int? KullaniciId { get; set; }

    [Column("KitapID")]
    public int? KitapId { get; set; }

    public int? Adet { get; set; }

    [ForeignKey("KitapId")]
    [InverseProperty("Sepets")]
    public virtual Kitaplar? Kitap { get; set; }

    [ForeignKey("KullaniciId")]
    [InverseProperty("Sepets")]
    public virtual Kullanicilar? Kullanici { get; set; }
}
