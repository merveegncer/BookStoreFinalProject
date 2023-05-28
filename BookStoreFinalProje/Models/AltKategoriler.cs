using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookStoreFinalProje.Models;

[Table("AltKategoriler")]
public partial class AltKategoriler
{
    [Key]
    [Column("AltKategoriID")]
    public int AltKategoriId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? AltKategoriAdi { get; set; }

    [Column("KategoriID")]
    public int? KategoriId { get; set; }

    [ForeignKey("KategoriId")]
    [InverseProperty("AltKategorilers")]
    public virtual Kategoriler? Kategori { get; set; }

    [InverseProperty("AltKategori")]
    public virtual ICollection<Kitaplar> Kitaplars { get; set; } = new List<Kitaplar>();
}
