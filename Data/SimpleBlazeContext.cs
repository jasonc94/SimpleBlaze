using Microsoft.EntityFrameworkCore;
using SimpleBlazorApp.Models;

namespace SimpleBlazorApp.Data
{
	public class SimpleBlazeContext : DbContext
	{
		public SimpleBlazeContext(DbContextOptions options) : base(options) 
		{
		}

		public DbSet<WorkItem> Tasks { get; set; }
	}
}
