using Microsoft.EntityFrameworkCore;
using SimpleBlazorApp.Data;
using SimpleBlazorApp.Models;

namespace SimpleBlazorApp.Repository
{
	public interface ITaskRepository
	{
		Task<List<WorkItem>> GetAllTask();
		Task AddNewTask(WorkItem workItem);
		Task DeleteTask(WorkItem workItem);
		Task UpdateTask(WorkItem workItem);


	}
	public class TaskRepository : ITaskRepository
	{
		private readonly SimpleBlazeContext _context;

		public TaskRepository(SimpleBlazeContext context)
		{
			_context = context;
		}

		public async Task<List<WorkItem>> GetAllTask()
		{
			return await _context.Tasks.ToListAsync();
		}

		public async Task AddNewTask(WorkItem workItem)
		{
			_context.Tasks.Add(workItem);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteTask(WorkItem workItem)
		{
			_context.Tasks.Remove(workItem);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateTask(WorkItem workItem)
		{
			_context.Tasks.Update(workItem);
			await _context.SaveChangesAsync();
		}
	}
}
