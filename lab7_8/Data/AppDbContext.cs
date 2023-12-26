using Microsoft.EntityFrameworkCore;
using lab7_8.Models;

namespace lab7_8.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<EmployeeModel> Employees { get; set; }
	}
}
