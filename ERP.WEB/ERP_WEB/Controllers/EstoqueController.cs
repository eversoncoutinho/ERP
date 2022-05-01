using Application.VM;
using Domain.Entities;
using Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace ERP_WEB.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly ERPDbContext _context;

        public EstoqueController(ERPDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index( )
        {
            //Lista de todas as compras
            var compraList = await _context.Compras.ToListAsync();

            //TO DO Selecionar a lista da tabela produto
            var produtoList = compraList.Select(n => n.Nome).Distinct().ToList();

            var estoqueLista = new List<EstoqueNomeQuantVM>();

            foreach (var prod in produtoList)
            {
                var somaCompra = _context.Compras.Where(n => n.Nome == prod).Sum(n => n.Quantidade);
                var somaConsum = _context.Consumos.Where(n => n.Nome == prod).Sum(n => n.Quantidade);
                
                var estoqueNomeQuantVM = new EstoqueNomeQuantVM()
                {
                    Nome = prod,
                    Quantidade = somaCompra-somaConsum
                };

                estoqueLista.Add(estoqueNomeQuantVM);
            }

            return View(estoqueLista.ToList());
        }


    }
}
