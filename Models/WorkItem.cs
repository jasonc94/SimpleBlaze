namespace SimpleBlazorApp.Models
{
    public class WorkItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
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
