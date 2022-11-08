namespace TutorialASP.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Lastname { get; set; } = String.Empty;
        public DateOnly BirthDate { get; set; }
        public string Place { get; set; } = String.Empty;

    }
}
