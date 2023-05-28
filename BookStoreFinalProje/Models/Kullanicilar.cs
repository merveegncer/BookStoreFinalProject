using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookStoreFinalProje.Models;

[Table("Kullanicilar")]
public partial class Kullanicilar
{
    [Key]
    [Column("KullaniciID")]
    public int KullaniciId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? KullaniciAdi { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Sifre { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Ad { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Soyad { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Rol { get; set; }

    [InverseProperty("Kullanici")]
    public virtual ICollection<Sepet> Sepets { get; set; } = new List<Sepet>();

    [InverseProperty("Kullanici")]
    public virtual ICollection<Siparisler> Siparislers { get; set; } = new List<Siparisler>();
}
