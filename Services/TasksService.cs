using SimpleBlazorApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlazorApp.Services
{
	public interface ITasksService
	{
		event Action OnStateChanged;
		List<WorkItem> GetAllTasks();
		Task DeleteTask(WorkItem task);

		Task AddNewTask(WorkItem task);

		Task UpdateTask(WorkItem task);

	}
	public class TasksService : ITasksService
	{
		public List<WorkItem> TaskList = new List<WorkItem>();
		public event Action OnStateChanged;

		public TasksService() {
			TaskList = new List<WorkItem>
			{
				new WorkItem()
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Create Task Page",
					Description = "Create Task Page",
					CreatedDateTime = DateTime.UtcNow,
					Status = Models.TaskStatus.InProgress
				},
				new WorkItem()
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Create Video Search Page",
					Description = "Create Video Search Page",
					CreatedDateTime = DateTime.UtcNow,
					Status = Models.TaskStatus.New
				},
				new WorkItem()
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Create GIf Search Page",
					Description = "Create GIf Search Page",
					CreatedDateTime = DateTime.UtcNow,
					Status = Models.TaskStatus.New
				},
			};
		}

		public async Task AddNewTask(WorkItem task)
		{
			TaskList.Add(task);
			OnStateChanged?.Invoke();
		}

		public async Task DeleteTask(WorkItem task)
		{
			TaskList.RemoveAll(t => t.Id == task.Id);
			OnStateChanged?.Invoke();
		}

		public List<WorkItem> GetAllTasks()
		{
			return TaskList;
		}

		public async Task UpdateTask(WorkItem task)
		{
			var index = TaskList.FindIndex(t => t.Id == task.Id);
			if (index != -1)
			{
				TaskList[index] = task;
				OnStateChanged?.Invoke();
			}
		}
	}
}
