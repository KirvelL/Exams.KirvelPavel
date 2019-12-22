using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Card
    {
        [Key]
        public Guid Number { get; set; }
        public Guid UserId { get; set; }
        public string NameCardOwner { get; set; }
        public double? Summ { get; set; }
        public bool? Block { get; set; } = false;
    }
}
