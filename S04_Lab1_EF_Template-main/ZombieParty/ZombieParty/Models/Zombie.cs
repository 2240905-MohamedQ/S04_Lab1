using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZombieParty.Models
{
    public class Zombie
    {
        public int Id { get; set; }
        [Required, StringLength(20, MinimumLength =5)]
        public string Name { get; set; }
        // FACULTATIF on peut formellement identifier le champ lien
        // sinon le champ de foreignKey sera auto généré dans la BD
        [Display(Name = "Zombie Type")]
        [ForeignKey("ZombieType")]
        public int ZombieTypeId { get; set; }
        public ZombieType ZombieType { get; set; }
        [Range(1, 20)]
        public int Point { get; set; }
        [StringLength(255)]
        public string ShortDesc { get; set; }
       
    }
}
