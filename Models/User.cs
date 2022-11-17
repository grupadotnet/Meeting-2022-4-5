using System.ComponentModel.DataAnnotations;

namespace TutorialASP.Models
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }
        [MaxLength(13)]
        public string Name { get; set; } = String.Empty;
        [MaxLength(30)] // najdłuższe polskie nazwisko Achmistrowicz-Wachmistrowicz
        public string LastName { get; set; } = String.Empty;
        public string Place { get; set; } = String.Empty;

    }
}
