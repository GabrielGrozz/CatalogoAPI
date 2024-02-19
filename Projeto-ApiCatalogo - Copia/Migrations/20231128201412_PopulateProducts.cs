using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_ApiCatalogo.Migrations
{
    public partial class PopulateProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO products(Name, Description, Price, stock, RegisterData, CategoryId) " +
                "VALUES('GTX 1660 Super','Placa de video responsável por dar vídeo no computador', 1250.00, 78, now(), 4)");

            mb.Sql("INSERT INTO products(Name, Description, Price, stock, RegisterData, CategoryId) " +
                "VALUES('GTA 5','Jogo de ação da Rockstar Games', 200.00, 23, now(), 5)");

            mb.Sql("INSERT INTO products(Name, Description, Price, stock, RegisterData, CategoryId) " +
                "VALUES('Monitor Centauri 165hz','Monitor da marca pichau de 165hz', 998.00, 09, now(), 6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from products");
        }
    }
}
