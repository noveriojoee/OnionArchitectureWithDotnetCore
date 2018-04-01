using System;
using Microsoft.EntityFrameworkCore;
using ResvCo.Models;

namespace ResvCo.Db
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }
        
        public DbSet<Band> Bands { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
