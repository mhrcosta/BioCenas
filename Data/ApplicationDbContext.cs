using BioCenas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BioCenas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //************************************************************************
        // especificar as tabelas na BD
        //************************************************************************
        public DbSet<CategoriaMDL> Categorias { get; set; }
        public DbSet<EncomendaMDL> Encomendas { get; set; }
        public DbSet<MoradaMDL> Moradas { get; set; }
        public DbSet<ImagemMDL> Imagens { get; set; }
        public DbSet<ProdutoMDL> Produtos { get; set; }
        public DbSet<DescritivoEncomendaMDL> DescritivoEncomendas { get; set; }
        public DbSet<RestricaoAlimentarMDL> RestricaoAlimentares { get; set; }
        public DbSet<UtilizadorMDL> Utilizadores { get; set; }
        //************************************************************************
    }
}
