using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configuration
{
    public class ContextBase : DbContext
    {
        /// <summary>
        /// A função abaixo permite que caso nâo exista a base de dados ela será criada
        /// </summary>
        /// <param name="options"></param>
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Essa linha abaixo é necessaria para criar um construtor baseado nele
        /// </summary>
        public DbSet<Product> Product { get; set; }


        /// <summary>
        /// Se não estiver configurado corretamente a função abaixo gera erro na conexção
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se não estiver configurado no projeto IU pega deginição de chame do json configurado
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStringConectionConfig());
            base.OnConfiguring(optionsBuilder);
        }


        /// <summary>
        /// A função abaixo é a conexão com o banco de dados, nesse caso ele é
        /// microsoft SQL Server Management Studio
        /// Nome do servidor: DESKTOP-MTD116I
        /// Nome da tabela: BancoReal
        /// Autenticação do Windows
        /// </summary>
        /// <returns></returns>
        private string GetStringConectionConfig()
        {
            string strCon = "Data Source=DESKTOP-MTD116I;Initial Catalog=BancoReal;Integrated Security=True;Connect Timeout=15;Trusted_Connection=Yes;";
            return strCon;
        }


    }
}
