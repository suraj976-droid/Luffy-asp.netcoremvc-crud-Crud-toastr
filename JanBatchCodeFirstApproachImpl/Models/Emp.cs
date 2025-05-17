using System.ComponentModel.DataAnnotations;

namespace JanBatchCodeFirstApproachImpl.Models
{
    public class Emp
    {
        [Key]
        public int eid { get; set; }

        [Required]
        public string ename { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
         public double salary { get; set; }
    }
}
