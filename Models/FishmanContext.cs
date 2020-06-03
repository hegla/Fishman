using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fishman.Models
{
    public class FishmanContext: DbContext
    {

        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<CitySalers> CitySalers { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Fishes> Fishes { get; set; }
        public virtual DbSet<Salers> Salers { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }

        public FishmanContext(DbContextOptions<FishmanContext> options): base(options)
        {
            Database.EnsureCreated();
        }

    }
}
