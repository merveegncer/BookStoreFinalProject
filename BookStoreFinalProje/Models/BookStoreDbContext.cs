using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookStoreFinalProje.Models;

public partial class BookStoreDbContext : DbContext
{
    public BookStoreDbContext()
    {
    }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AltKategoriler> AltKategorilers { get; set; }

    public virtual DbSet<Kategoriler> Kategorilers { get; set; }

    public virtual DbSet<Kitaplar> Kitaplars { get; set; }

    public virtual DbSet<Kullanicilar> Kullanicilars { get; set; }

    public virtual DbSet<Sepet> Sepets { get; set; }

    public virtual DbSet<SiparisDetaylari> SiparisDetaylaris { get; set; }

    public virtual DbSet<Siparisler> Siparislers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDB;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AltKategoriler>(entity =>
        {
            entity.HasKey(e => e.AltKategoriId).HasName("PK__AltKateg__783F4127A6DA3E83");

            entity.Property(e => e.AltKategoriId).ValueGeneratedNever();

            entity.HasOne(d => d.Kategori).WithMany(p => p.AltKategorilers).HasConstraintName("FK__AltKatego__Kateg__267ABA7A");
        });

        modelBuilder.Entity<Kategoriler>(entity =>
        {
            entity.HasKey(e => e.KategoriId).HasName("PK__Kategori__1782CC92E40806E7");

            entity.Property(e => e.KategoriId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Kitaplar>(entity =>
        {
            entity.HasKey(e => e.KitapId).HasName("PK__Kitaplar__89491B2CF4951E06");

            entity.Property(e => e.KitapId).ValueGeneratedNever();

            entity.HasOne(d => d.AltKategori).WithMany(p => p.Kitaplars).HasConstraintName("FK__Kitaplar__AltKat__2C3393D0");
        });

        modelBuilder.Entity<Kullanicilar>(entity =>
        {
            entity.HasKey(e => e.KullaniciId).HasName("PK__Kullanic__E011F09B785EE016");

            entity.Property(e => e.KullaniciId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Sepet>(entity =>
        {
            entity.HasKey(e => e.SepetId).HasName("PK__Sepet__97CA09D358F3D6F8");

            entity.Property(e => e.SepetId).ValueGeneratedNever();

            entity.HasOne(d => d.Kitap).WithMany(p => p.Sepets).HasConstraintName("FK__Sepet__KitapID__31EC6D26");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Sepets).HasConstraintName("FK__Sepet__Kullanici__30F848ED");
        });

        modelBuilder.Entity<SiparisDetaylari>(entity =>
        {
            entity.HasKey(e => e.SiparisDetayId).HasName("PK__SiparisD__DA4BD8322DCD453C");

            entity.Property(e => e.SiparisDetayId).ValueGeneratedNever();

            entity.HasOne(d => d.Kitap).WithMany(p => p.SiparisDetaylaris).HasConstraintName("FK__SiparisDe__Kitap__38996AB5");

            entity.HasOne(d => d.Siparis).WithMany(p => p.SiparisDetaylaris).HasConstraintName("FK__SiparisDe__Sipar__37A5467C");
        });

        modelBuilder.Entity<Siparisler>(entity =>
        {
            entity.HasKey(e => e.SiparisId).HasName("PK__Siparisl__C3F03BDD5EFE3C8C");

            entity.Property(e => e.SiparisId).ValueGeneratedNever();

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Siparislers).HasConstraintName("FK__Siparisle__Kulla__34C8D9D1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
