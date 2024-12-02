using Microsoft.EntityFrameworkCore;

namespace AS.Data
{
    public class AppDbContext : DbContext
    {
        // Define uma tabela "Pedidos" no banco de dados
        public DbSet<Pedido> Pedidos { get; set; }

        // Define uma tabela "Fornecedores" no banco de dados
        public DbSet<Fornecedor> Fornecedores { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             // Configura o uso do SQLite como banco de dados
            optionsBuilder.UseSqlite("Data Source=pedidos.db");
        }
    }
}
