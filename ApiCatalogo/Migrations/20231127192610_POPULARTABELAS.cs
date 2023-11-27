using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    public partial class POPULARTABELAS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into categories(Name, Description) Values('eletronico', 'peças de hardware, video-games, tvs e afins')");

            migrationBuilder.Sql("Insert into categories(Name, Description) Values('jogos', 'jogos de video-game')");

            migrationBuilder.Sql("Insert into categories(Name, Description) Values('perifericos', 'aparelho que envia e recebe informações de um computador.')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from categories");
        }
    }
}
