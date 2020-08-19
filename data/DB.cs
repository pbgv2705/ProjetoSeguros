using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace data
{
    public class DB : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Corretor> Corretores { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=totiNovo;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cliente>()
            .Property(e => e.NomeCliente)
            .HasMaxLength(100)
            .IsRequired();

            builder.Entity<Cliente>()
            .Property(e => e.Cpf)
            .IsRequired();
            
            builder.Entity<Cliente>()
            .HasOne(e => e.Corretor)
            .WithMany()
            .HasForeignKey(e => e.CorretorId);

            builder.Entity<Corretor>()
             .Property(e => e.RMCreci)
            .IsRequired();
        
        }
       
    }
}