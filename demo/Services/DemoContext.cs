using System;
using demo.Models;
using Microsoft.EntityFrameworkCore;

namespace demo.Services
{
	public class DemoContext : DbContext
	{
		public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {
			Database.EnsureCreated();
        }
		public DbSet<Blog> Blogs { get; set; }
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Blog>();
		}
	}
}

