using Microsoft.EntityFrameworkCore;
using Banco.Models;

namespace Banco.Data
{
    public class BancoContext : DbContext
    {

        public BancoContext(DbContextOptions<BancoContext> options)
            : base(options){ }

        public DbSet<Banco.Models.UsuarioAgencia>? UsuarioAgencia { get; set; }
    }

}
