using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Infra.Data;
using Application.VM;
using AutoMapper;
using Domain.Entities;
using System.Globalization;
using System.Threading;

namespace ERP_WEB.Controllers
{
    public class ComprasController : Controller
    {
        //Para Capitalizar as palavras
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;


        private readonly ERPDbContext _context;
        private readonly IMapper _mapper;

        public ComprasController(ERPDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()

        {
            var produtoVM = new CompraIndexVM()
            {
                Compras = await _context.Compras.ToListAsync()

            };           
            
            return View(produtoVM);
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Compras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompraCreateVM produtoVM)
        {
            CompraCreateVM produtoCreateVM = new CompraCreateVM()
            {
                Price = produtoVM.Price.Replace('.',','),
                DateTime = produtoVM.DateTime,
                Nome = produtoVM.Nome,
                Fornecedor = produtoVM.Fornecedor,
                Quantidade = produtoVM.Quantidade              
                
            };
            

            if (ModelState.IsValid)
            {
                
                var produto = new Compra
                {
                    
                    Nome = ti.ToTitleCase(produtoVM.Nome.Trim()),
                    DateTime=produtoCreateVM.DateTime,
                    Fornecedor=produtoVM.Fornecedor,
                    Quantidade=produtoVM.Quantidade,
                    Price = decimal.Parse(produtoCreateVM.Price)
                };
                produto.Total=produto.TotalCal(produto.Price, produto.Quantidade);
                _context.Add(produto);
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produtoVM);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Compras.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,DateTime,Price,Quantidade,Fornecedor,Id")] Compra produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Compras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Compras.FindAsync(id);
            _context.Compras.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Compras.Any(e => e.Id == id);
        }
    }
}
