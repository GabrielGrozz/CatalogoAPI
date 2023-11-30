using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_ApiCatalogo.Migrations
{
    public partial class PopulateCategories : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {

            mb.Sql("Insert into categories(Name, Description) Values('eletronico','peças de hardware, video-games, tvs e afins')");

            mb.Sql("Insert into categories(Name, Description) Values('jogos', 'jogos de video-game')");

            mb.Sql("Insert into categories(Name, Description) Values('perifericos', 'aparelho que envia e recebe informações de um computador.')");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from categories");
        }
    }
}
