using System.ComponentModel.DataAnnotations;

namespace TutorialASP.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        [MaxLength(13)]
        public string LastName { get; set; } = String.Empty;
        [MaxLength(30)] // najdłuższe polskie nazwisko Achmistrowicz-Wachmistrowicz
        public string Place { get; set; } = String.Empty;

    }
}
