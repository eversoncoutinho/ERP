using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VM
{
    public  class ProdutoCreateVM
    {
        public string Nome { get; set; }
        public DateTime DateTime { get; set; }
        public string Price { get; set; }
        public int Quantidade { get; set; }
        public string Fornecedor { get; set; }

    }

}
