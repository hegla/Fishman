using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fishman.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        public int SalerId { get; set; }
        public int FishId { get; set; }
        public virtual Salers Saler { get; set; }
        public virtual Fishes Fish { get; set; }
    }
}
