namespace TutorialASP.Models
{
    public class User
    {
        public Guid id { get; set; }
        public string name { get; set; } = String.Empty;
        public string lastname { get; set; } = String.Empty;
        public DateOnly birthDate { get; set; }
        public string place { get; set; } = String.Empty;

    }
}
