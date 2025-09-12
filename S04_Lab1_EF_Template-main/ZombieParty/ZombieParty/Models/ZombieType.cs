using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class ZombieType
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Type Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} has to be filled."),StringLength(10, MinimumLength =5)]
        public string TypeName { get; set; }
        [Range(2, 5)]
        public int Point {  get; set; }
    }
}
