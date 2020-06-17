using Microsoft.EntityFrameworkCore;
using RestApiDemo.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiDemo.Data
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<NationalPark> nationalParks { get; set; }
        public DbSet<Trial> trial { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
