using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZombieParty.Models
{
    public class Zombie
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} has to be filled.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} requires a length between {2} and {1} characters.")]
        public string Name { get; set; }

        [Display(Name = "Zombie Type")]
        [ForeignKey("ZombieType")]
        [Required(ErrorMessage = "{0} has to be filled.")]
        public int ZombieTypeId { get; set; }

        public ZombieType ZombieType { get; set; }

        [Range(1, 20, ErrorMessage = "{0} requires a value between {1} and {2}.")]
        public int Point { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} has to be filled.")]
        [StringLength(255, ErrorMessage = "{0} cannot exceed {1} characters.")]
        public string ShortDesc { get; set; }
    }
}
