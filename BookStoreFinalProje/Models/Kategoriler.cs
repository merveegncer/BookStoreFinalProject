using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookStoreFinalProje.Models;

[Table("Kategoriler")]
public partial class Kategoriler
{
    [Key]
    [Column("KategoriID")]
    public int KategoriId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? KategoriAdi { get; set; }

    [InverseProperty("Kategori")]
    public virtual ICollection<AltKategoriler> AltKategorilers { get; set; } = new List<AltKategoriler>();
}
