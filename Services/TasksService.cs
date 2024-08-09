using SimpleBlazorApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlazorApp.Services
{
	public interface ITasksService
	{
		List<WorkItem> GetAllTasks();
		bool DeleteTask(WorkItem task);

		bool AddNewTask(WorkItem task);

		bool UpdateTask(WorkItem task);

	}
	public class TasksService : ITasksService
	{
		public List<WorkItem> TaskList = new List<WorkItem>();

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

		public bool AddNewTask(WorkItem task)
		{
			TaskList.Add(task);
			return true;
		}

		public bool DeleteTask(WorkItem task)
		{
			TaskList.RemoveAll(t => t.Id == task.Id);
			return true;
		}

		public List<WorkItem> GetAllTasks()
		{

			return TaskList;
		}

		public bool UpdateTask(WorkItem task)
		{
			var index = TaskList.FindIndex(t => t.Id == task.Id);
			if (index == -1)
			{
				return false;
			}
			TaskList[index] = task;
			return true;
		}
	}
}
