using System.ComponentModel.DataAnnotations;

namespace SimpleBlazorApp.Models
{
    public class WorkItem
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Task Name is required")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? CompletedDateTime { get; set; }
    }

    public enum TaskStatus
    {
        New,
        InProgress,
        Complete
    }
}
