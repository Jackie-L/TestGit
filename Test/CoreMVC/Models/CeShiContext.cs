using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Models
{
    public class CeShiContext: DbContext
    {
        public CeShiContext(DbContextOptions<CeShiContext> options)
            : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=.;database=TestDb;user=root;password=123456;");
        //}
        public DbSet<LC_Test> LC_Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LC_Test>().ToTable("LC_Test");

            base.OnModelCreating(modelBuilder);
        }

    }
}
