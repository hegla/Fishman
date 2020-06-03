using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fishman.Models
{
    public class CitySalers
    {
        [Key]
        public int Id { get; set; }
        public int SalerId { get; set; }
        public int CityId { get; set; }
        public virtual Salers Saler { get; set; }
        public virtual Cities City { get; set; }
    }
}