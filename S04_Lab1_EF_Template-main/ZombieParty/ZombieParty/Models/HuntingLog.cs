using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class HuntingLog
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(25, MinimumLength = 5, ErrorMessage = "{0} requires between {2} and {1} characters.")]
        public string Title { get; set; }

        [StringLength(255, ErrorMessage = "{0} cannot exceed {1} characters.")]
        public string Description { get; set; }

        // Propriétés de navigation (on les ajoutera après le test initial)
        public List<Zombie> Zombies { get; set; } = new List<Zombie>();

    }
}
