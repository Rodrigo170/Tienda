﻿
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Infrastructure.Data;
public class TiendaContext : DbContext
{
    public TiendaContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Producto> Productos { get; set; }
    public DbSet<Marca> Marcas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
