using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fishman.Models
{
    public class Cities
    {
        public Cities()
        {
            CitySalers = new List<CitySalers>();
        }
        [Key]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public long Population { get; set; }
        public virtual ICollection<CitySalers> CitySalers { get; set; }
    }
}
