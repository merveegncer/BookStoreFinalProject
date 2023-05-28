using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookStoreFinalProje.Models;

[Table("Kitaplar")]
public partial class Kitaplar
{
    [Key]
    [Column("KitapID")]
    public int KitapId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? KitapAdi { get; set; }

    [Column("AltKategoriID")]
    public int? AltKategoriId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Fiyat { get; set; }

    [Column(TypeName = "date")]
    public DateTime? YayinTarihi { get; set; }

    [StringLength(1000)]
    public string? KitapAciklama { get; set; }

    [Column(TypeName = "varchar(100)")]

    [DisplayName("image full name")]
    public string? KitapFoto { get; set; }

    [NotMapped]
    [DisplayName("upload image file")]
    public IFormFile ImageFile { get; set; }

    [StringLength(50)]
    public string? YazarAdi { get; set; }

    public int? StokMiktari { get; set; }

    [ForeignKey("AltKategoriId")]
    [InverseProperty("Kitaplars")]
    public virtual AltKategoriler? AltKategori { get; set; }

    [InverseProperty("Kitap")]
    public virtual ICollection<Sepet> Sepets { get; set; } = new List<Sepet>();

    [InverseProperty("Kitap")]
    public virtual ICollection<SiparisDetaylari> SiparisDetaylaris { get; set; } = new List<SiparisDetaylari>();
}
