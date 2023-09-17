using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banco.Migrations
{
    /// <inheritdoc />
    public partial class context : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioAgencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Conta = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Agencia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    permissao = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioAgencia", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioAgencia");
        }
    }
}
