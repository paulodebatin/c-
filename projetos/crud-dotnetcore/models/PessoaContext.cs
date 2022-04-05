using Microsoft.EntityFrameworkCore;

namespace backend_dotnetcore.models
{
    public class PessoaContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public PessoaContext(DbContextOptions<PessoaContext> options) :
            base(options)
        {
        }
    }
}