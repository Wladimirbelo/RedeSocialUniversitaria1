using Microsoft.EntityFrameworkCore;
using DDDRedeSocialUniversitaria.Domain;
using Microsoft.Extensions.Logging;

namespace DDDRedeSocialUniversitaria.Infra
{
    public class SqlContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RedeSocialDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais podem ser feitas aqui
        }
    }
}