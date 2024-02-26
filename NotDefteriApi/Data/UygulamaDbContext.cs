using Microsoft.EntityFrameworkCore;

namespace NotDefteriApi.Data
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext (DbContextOptions<UygulamaDbContext> options) : base(options)
        { 
        
        }

        public DbSet<Not> Notlar {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Not>().HasData(
                new Not() { Id = 1, Baslik = "Alışveriş Listesi", Icerik = "Süt, ekmek, yumurta ve elma alınacak." },
                new Not() { Id = 2, Baslik = "Kitap Önerileri", Icerik = "1. Sapiens, 2. Kürk Mantolu Madonna, 3. Fahrenheit 451" },
                new Not() { Id = 3, Baslik = "Haftalık Hedefler", Icerik = "Haftada 3 gün spor yapmak, her gün 2 litre su içmek ve erken yatmak." },
                new Not() { Id = 4, Baslik = "Toplantı Notları", Icerik = "Projede son durum değerlendirmesi yapılacak, yeni görev dağılımları konuşulacak." }
            );
        }
    }
}
