using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UniqueDrinks.Models;

namespace UniqueDrinks.Data
{
    /// <summary>
    /// esta classe representa a Base de Dados a ser utilizada neste projeto
    /// </summary>
    public class DrinksDB : IdentityDbContext
    {
        public DrinksDB(DbContextOptions<DrinksDB> options): base(options)
        {
        }

        //Representar as Tabelas da BD
        public DbSet<Bebidas> Bebidas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Imagens> Imagens { get; set; }
        public DbSet<Reservas> Reservas { get; set; }
    }
}
