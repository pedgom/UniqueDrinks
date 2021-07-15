using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniqueDrinks.Data.Migrations
{
    public partial class addData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Categoria" },
                values: new object[,]
                {
                    { 1, "Vinho" },
                    { 10, "Cerveja e Cidra" },
                    { 8, "Licores" },
                    { 7, "Cachaça e Aguardente" },
                    { 6, "Rum e Tequila" },
                    { 9, "Champanhe e Espumante" },
                    { 4, "Whisky" },
                    { 3, "Vinho Moscatel" },
                    { 2, "Vinho do Porto" },
                    { 5, "Gin e Vodka" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Contacto", "Datanasc", "Email", "Nome" },
                values: new object[,]
                {
                    { 6, 961883421, new DateTime(1985, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "bp@bp.com", "Beatriz Pinto" },
                    { 1, 937492122, new DateTime(1995, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "pr@pr.com", "Pedro Rafael" },
                    { 2, 920562956, new DateTime(1994, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "jv@jv.com", "Jose Vieira" },
                    { 3, 914659935, new DateTime(1999, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ms@ms.com", "Maria Silva" },
                    { 4, 936581003, new DateTime(1990, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "fs@fs.com", "Filipe Santos" },
                    { 5, 962813384, new DateTime(1998, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "as@as.com", "Ana Sousa" },
                    { 7, 917745362, new DateTime(1978, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "tm@tm.com", "Tiago Mendonça" }
                });

            migrationBuilder.InsertData(
                table: "Bebidas",
                columns: new[] { "Id", "CategoriaFK", "Descricao", "Imagem", "Nome", "Preco", "Stock" },
                values: new object[,]
                {
                    { 1, 1, " MATEUS ROSÉ é um vinho leve, fresco, jovem e ligeiramente «pétillant»", null, "Vinho Rose Mateus", 20m, "Sim" },
                    { 2, 2, "É vinificado pelo método tradicional do vinho do Porto.", null, "Vinho do Porto Ferreira", 30m, "Sim" },
                    { 3, 3, "Vinho Moscatel de Setúbal", null, "Veritas Moscatel", 10m, "Sim" },
                    { 4, 4, "Grant’s é um whisky extraordinário e um dos mais complexos produzidos na Escócia.", null, "Grants Whisky", 15m, "Sim" },
                    { 5, 5, "Cîroc Vodka é uma marca de vodca eau-de-vie de luxo, fabricada com uvas da região Carântono-Marítimo, da França", null, "Ciroc Vodka", 30m, "Sim" },
                    { 6, 6, "Nada bate um original, e Malibu não é apenas o original, é o mais vendido rum do Caribe com sabor natural de coco ", null, "Malibu Rum", 15m, "Sim" },
                    { 7, 7, "Cachaça, o sabor e aroma perfeito da original caipirinha brasileira.", null, "Cachaça 51", 11m, "Sim" },
                    { 8, 9, "Moet & Chandon, um champanhe de estilo único e elegante.", null, "Moet&Chandon", 50m, "Sim" },
                    { 9, 10, "O sabor autêntico. Super Bock Original é a única cerveja portuguesa com 37 medalhas de ouro consecutivas", null, "Super Bock Pack15", 7m, "Sim" }
                });

            migrationBuilder.InsertData(
                table: "Imagens",
                columns: new[] { "Id", "BebidaFK", "Imagem" },
                values: new object[,]
                {
                    { 1, 1, "Vinho-Mateus-Rose.jpg" },
                    { 8, 8, "moet_champanhe.jpg" },
                    { 7, 7, "51_cachaça.jpg" },
                    { 6, 6, "malibu_rum.jpg" },
                    { 9, 9, "superBock.jpg" },
                    { 4, 4, "grants_whisky.jpg" },
                    { 5, 5, "ciroc_vodka.jpg" },
                    { 3, 3, "veritas_moscatel.jpg" },
                    { 2, 2, "ferreira_Porto.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "Id", "BebidaFK", "ClienteFK", "DataEntrega", "DataReserva", "Estado", "Quantidade" },
                values: new object[,]
                {
                    { 4, 4, 4, new DateTime(2020, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entregue", 1 },
                    { 5, 5, 5, new DateTime(2020, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entregue", 5 },
                    { 2, 2, 2, new DateTime(2019, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entregue", 1 },
                    { 6, 6, 6, new DateTime(2020, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entregue", 2 },
                    { 7, 7, 7, new DateTime(2021, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entregue", 3 },
                    { 1, 1, 1, new DateTime(2019, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entregue", 2 },
                    { 8, 8, 3, new DateTime(2021, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entregue", 1 },
                    { 3, 3, 3, new DateTime(2019, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entregue", 1 },
                    { 11, 9, 2, new DateTime(2020, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entregue", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Bebidas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bebidas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bebidas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bebidas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bebidas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bebidas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bebidas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Bebidas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Bebidas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
