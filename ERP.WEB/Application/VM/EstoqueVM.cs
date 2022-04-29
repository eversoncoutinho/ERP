using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VM
{
    public class EstoqueVM
    {
        public Compra Compra { get; set; }
        public Consumo Consumo { get; set; }
        public decimal Saldo { get; set; }
    }
}
