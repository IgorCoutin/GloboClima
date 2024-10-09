using Microsoft.EntityFrameworkCore;
using GloboClima.API.Models;



namespace GloboClima.API.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            this.Database.SetCommandTimeout(600);
        }

        // ?TODO: REFACT THIS TO USE USE OTHER CONTEXTS TO DECREASE THE LINE NUMBERS
        public DbSet<User> Usuarios { get; set; }
       
        public DbSet<Grupos> Tb_Grupo { get; set; }


         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // USER JOINS
             modelBuilder.Entity<User>()
                .HasOne(u => u.GrupoJoin)
                .WithMany()
                .HasForeignKey(u => u.grupo);

        }
    }
}