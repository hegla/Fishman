using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fishman.Models
{
    public class Salers
    {
        public Salers()
        {
            CitySalers = new List<CitySalers>();
            Sales = new List<Sales>();
        }
        [Key]
        public int SalerId { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public long WorkersNumber { get; set; }
        public virtual ICollection<CitySalers> CitySalers { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }

    }
}