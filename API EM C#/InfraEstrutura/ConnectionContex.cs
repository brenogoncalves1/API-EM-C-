using API_EM_C_.Model;
using Microsoft.EntityFrameworkCore;
using static API_EM_C_.Model.Produtos;
using static API_EM_C_.Model.LoginModel;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\banco_BG;Database=PRD;Trusted_Connection=True;");
        }


    }
}
