using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace data
{
    public class DB : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public object Cliente { get; set; }

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
            .HasOne(e => e.Corretor)
            .WithMany()
            .HasForeignKey(e => e.RMCreci);
        }

        

        const string nomeDoArquivo = "data.json";

        public static IEnumerable<Cliente> LerClientesDoArquivo()
        {
            var conteudoArquivo = System.IO.File.ReadAllText(nomeDoArquivo);

            var lista = JsonSerializer.Deserialize<IEnumerable<Cliente>>(conteudoArquivo);

            return lista;
        }

        public static void SalvarClientesNoArquivo(IEnumerable<Cliente> novaLista)
        {
            var json = JsonSerializer.Serialize(novaLista);

            System.IO.File.WriteAllText(nomeDoArquivo, json);
        }
    }
}