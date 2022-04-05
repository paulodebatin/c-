using Microsoft.EntityFrameworkCore;

namespace backend_dotnetcore.models
{
    public class ProdutoContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public ProdutoContext(DbContextOptions<ProdutoContext> options) :
            base(options)
        {
        }
    }
}