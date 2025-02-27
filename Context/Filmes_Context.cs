using api_filmes_senai.Domains;
using Microsoft.EntityFrameworkCore;

namespace api_filmes_senai.Context
{
    public class Filmes_Context : DbContext
    {
        public Filmes_Context() { }

        public Filmes_Context(DbContextOptions<Filmes_Context> options) : base(options)
        {
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Filme> Filmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NOTE36-S28\\SQLEXPRESS; Database=Filmes; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true;");
            }
        }
    }
}
