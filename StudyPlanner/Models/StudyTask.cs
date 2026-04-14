namespace StudyPlanner.Models
{
    public class StudyTask
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Title { get; set; }

        public DateTime Deadline { get; set; }

        public bool IsDone { get; set; }

        public string Priority { get; set; }
    }
}
