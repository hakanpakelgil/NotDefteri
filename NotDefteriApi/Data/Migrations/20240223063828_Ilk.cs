using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NotDefteriApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Ilk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notlar", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Notlar",
                columns: new[] { "Id", "Baslik", "Icerik" },
                values: new object[,]
                {
                    { 1, "Alışveriş Listesi", "Süt, ekmek, yumurta ve elma alınacak." },
                    { 2, "Kitap Önerileri", "1. Sapiens, 2. Kürk Mantolu Madonna, 3. Fahrenheit 451" },
                    { 3, "Haftalık Hedefler", "Haftada 3 gün spor yapmak, her gün 2 litre su içmek ve erken yatmak." },
                    { 4, "Toplantı Notları", "Projede son durum değerlendirmesi yapılacak, yeni görev dağılımları konuşulacak." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notlar");
        }
    }
}
