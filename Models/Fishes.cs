using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fishman.Models
{
    public class Fishes
    {
        public Fishes()
        {
            Sales = new List<Sales>();
        }
        [Key]
        public int FishId { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public long Price { get; set; }
        public int CountryId { get; set; }
        public virtual Countries Country { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }

    }
}
