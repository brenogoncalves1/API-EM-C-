using API_EM_C_.Model;
using Microsoft.EntityFrameworkCore;

namespace API_EM_C_.InfraEstrutura
{
    public class ConnectionContex : DbContext
    {
        public ConnectionContex(DbContextOptions<ConnectionContex> options)
            : base(options)
        {
        }

        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<LoginModel> LoginModel { get; set; }

    }
}
