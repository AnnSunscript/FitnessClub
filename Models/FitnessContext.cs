using Microsoft.EntityFrameworkCore;

namespace FitnessClub.Models
{
    public class FitnessContext: DbContext

    {       
            public FitnessContext(DbContextOptions<FitnessContext> options) : base(options)
            {

            }
            public DbSet<Clients> Clients { get; set; }
            public DbSet<Trainers> Trainers { get; set; }
            public DbSet<Services> Services { get; set; }
            public DbSet<Orders> Orders { get; set; }
        

    }
}
