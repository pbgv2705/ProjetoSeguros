﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using data;

namespace data.Migrations
{
    [DbContext(typeof(DB))]
    partial class DBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("data.Cliente", b =>
                {
                    b.Property<int>("Cpf")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Apolice")
                        .HasColumnType("int");

                    b.Property<bool>("Cancelado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("Prime")
                        .HasColumnType("float");

                    b.Property<int?>("RMCreci")
                        .HasColumnType("int");

                    b.Property<long>("Telefone")
                        .HasColumnType("bigint");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cpf")
                        .HasName("PrimaryKey_ClienteCpf");

                    b.HasIndex("RMCreci");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("data.Corretor", b =>
                {
                    b.Property<int>("RMCreci")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeCorretor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RMCreci")
                        .HasName("PrimaryKey_CorretorRMCreci");

                    b.ToTable("Corretores");
                });

            modelBuilder.Entity("data.Cliente", b =>
                {
                    b.HasOne("data.Corretor", "Corretor")
                        .WithMany()
                        .HasForeignKey("RMCreci");
                });
#pragma warning restore 612, 618
        }
    }
}
