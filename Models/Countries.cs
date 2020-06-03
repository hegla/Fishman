using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fishman.Models
{
    public class Countries
    {
        public Countries()
        {
            Fishes = new List<Fishes>();
        }
        [Key]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public long Population { get; set; }
        public virtual ICollection<Fishes> Fishes { get; set; }
    }
}