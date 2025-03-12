using Microsoft.EntityFrameworkCore;
using Parcia1.Models;
using System.Collections.Generic;

namespace Parcia1.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Students>Students{ get; set; }
    }
}