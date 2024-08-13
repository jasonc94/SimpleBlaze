using SimpleBlazorApp.Models;
using SimpleBlazorApp.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlazorApp.Services
{
	public interface ITasksService
	{
		event Action OnStateChanged;
		Task<List<WorkItem>> GetAllTasks();
		Task DeleteTask(WorkItem task);

		Task AddNewTask(WorkItem task);

		Task UpdateTask(WorkItem task);

	}
	public class TasksService : ITasksService
	{
		public List<WorkItem> TaskList = new List<WorkItem>();
		public event Action? OnStateChanged;
		private readonly ITaskRepository _taskRepository;

		public TasksService(ITaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}

		//public TasksService() {
		//	TaskList = new List<WorkItem>
		//	{
		//		new WorkItem()
		//		{
		//			Id = Guid.NewGuid().ToString(),
		//			Name = "Create Task Page",
		//			Description = "Create Task Page",
		//			CreatedDateTime = DateTime.UtcNow,
		//			Status = Models.TaskStatus.InProgress
		//		},
		//		new WorkItem()
		//		{
		//			Id = Guid.NewGuid().ToString(),
		//			Name = "Create Video Search Page",
		//			Description = "Create Video Search Page",
		//			CreatedDateTime = DateTime.UtcNow,
		//			Status = Models.TaskStatus.New
		//		},
		//		new WorkItem()
		//		{
		//			Id = Guid.NewGuid().ToString(),
		//			Name = "Create GIf Search Page",
		//			Description = "Create GIf Search Page",
		//			CreatedDateTime = DateTime.UtcNow,
		//			Status = Models.TaskStatus.New
		//		},
		//	};
		//}

		public async Task AddNewTask(WorkItem task)
		{
			await _taskRepository.AddNewTask(task);
			OnStateChanged?.Invoke();
		}

		public async Task DeleteTask(WorkItem task)
		{
			await _taskRepository.DeleteTask(task);
			OnStateChanged?.Invoke();
		}

		public async Task<List<WorkItem>> GetAllTasks()
		{
			return await _taskRepository.GetAllTask();
		}

		public async Task UpdateTask(WorkItem task)
		{
			await _taskRepository.UpdateTask(task); 
			OnStateChanged?.Invoke();
		}
	}
}
