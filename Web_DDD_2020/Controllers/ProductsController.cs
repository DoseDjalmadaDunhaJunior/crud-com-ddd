using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities.Entities;
using Infrastructure.Configuration;
using ApplicationApp.Interfaces;

/// <summary>
/// Foi um controlador MVC usando Entity Framework
/// Modelo Product: (Entities.Entities)
/// Contexto: ContextBase (Infraestruture.Configuration)
/// </summary>
/// 
namespace Web_DDD_2020.Controllers
{

    public class ProductsController : Controller
    {
        private readonly InterfaceProductApp _InterfaceProductApp;

        public ProductsController(InterfaceProductApp InterfaceProductApp)
        {
            _InterfaceProductApp = InterfaceProductApp;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _InterfaceProductApp.List());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _InterfaceProductApp.GetEntityById((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Preco,Ativo,Id,Nome")] Product product)
        {
            if (ModelState.IsValid)
            {

                await _InterfaceProductApp.AddProduct(product);

                // o if abaixo ele lista todas as notificações que tiver e se tiver
                if (product.Notitycoes.Any())
                {
                    foreach (var item in product.Notitycoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }

                    return View("Create", product);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _InterfaceProductApp.GetEntityById((int)id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Preco,Ativo,Id,Nome")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //aqui as coisas são parecidas com o create, com suas respectivas peculiaridades mas basicamente é um ((ctrl + c) + (ctrl + v))

                    await _InterfaceProductApp.UpdateProduct(product);

                    if (product.Notitycoes.Any())
                    {
                        foreach(var item in product.Notitycoes)
                        {
                            ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                        }
                        // a diferença fica aqui, em vez de craate é edit
                        return View("Edit", product);

                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _InterfaceProductApp.GetEntityById((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _InterfaceProductApp.GetEntityById(id);
            await _InterfaceProductApp.Delete(product);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProductExists(int id)
        {

            var objeto = await _InterfaceProductApp.GetEntityById(id);

            return objeto != null;
        }
    }
}
