using Microsoft.EntityFrameworkCore;
using testOracleApp1.Models;

namespace testOracleApp1.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }
	}
}
