using Microsoft.EntityFrameworkCore;
using WebMinimalApiNet6.Data.Mappings;
using WebMinimalApiNet6.Models;

namespace WebMinimalApiNet6.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Tarefas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaMap());
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
