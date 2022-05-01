using Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.VM
{
    public  class CompraCreateVM
    {
        public int Id { get; set; }
        [Display(Name = "Produto")]
        public string Nome { get; set; }
        [Display(Name  = "Data da Compra")]
        public DateTime DateTime { get; set; }
        [Display(Name = "Preço unitário")]
        public string Price { get; set; }
        public int Quantidade { get; set; }
        public EUnidade Unidades { get; set; }
        public string Fornecedor { get; set; }

    }

}
