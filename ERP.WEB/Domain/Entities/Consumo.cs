using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Consumo:Entity
    {
        [Display(Name = "Produto")]
        public string Nome { get; set; }

        [Display(Name = "Data de Levantamento")]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        public int Quantidade { get; set; }
    }
}
