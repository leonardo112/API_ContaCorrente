using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_ContaCorrente.Models
{
    public class ContaCorrente
    {
        [Key]
        public int ID { get; set; }
        public double Saldo { get; set; }
    }
}
