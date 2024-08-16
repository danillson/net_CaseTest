using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebApi.Entities;

namespace WebApi.Config
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }

        public DbSet<PessoaModel> Pessoa { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PessoaModel>().ToTable("Pessoa").HasKey(t => t.Id);
        
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public string ObterStringConexao()
        {
            return "Data Source=localhost\\SQLEXPRESS;Initial Catalog=case_teste_api;Integrated Security=SSPI;TrustServerCertificate=true";
        }

    }
}
