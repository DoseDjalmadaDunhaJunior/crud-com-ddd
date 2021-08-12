using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{

    /// <summary>
    /// Essa classe tenta fazer a comunicação do dominio com a aplication
    /// A interface foi implementada com o (Ctrl + .)
    /// Praticamente todas as funções tem que ser async
    /// dentro dessas funções async elas tem que ter um aweit
    /// </summary>
    public class AppProduct : InterfaceProductApp
    {
        /// <summary>
        /// O IProduct e o IServiceProduct são as interfacse no domain
        /// </summary>
        IProduct _IProduct;
        IServiceProduct _IServiceProduct;

        /// <summary>
        /// Essa função abaixo é o construtor
        /// </summary>
        /// <param name="IProduct"></param>
        /// <param name="IServiceProduct"></param>
        public AppProduct(IProduct IProduct, IServiceProduct IServiceProduct)
        {
            _IProduct = IProduct;
            _IServiceProduct = IServiceProduct;
        }

        public async Task Add(Product Objeto)
        {
            await _IProduct.Add(Objeto);
        }

        public async Task Delete(Product Objeto)
        {
            await _IProduct.Delete(Objeto);
        }

        public async Task<Product> GetEntityById(int Id)
        {
            return await _IProduct.GetEntityById(Id);
        }

        public async Task<List<Product>> List()
        {
            return await _IProduct.List();
        }

        public async Task Update(Product Objeto)
        {
            await _IProduct.Update(Objeto);
        }

        #region Metodos customizados
        public async Task AddProduct(Product product)
        {
            await _IServiceProduct.AddProduct(product);
        }

        public async Task UpdateProduct(Product product)
        {
            await _IServiceProduct.UpdateProduct(product);
        }
        #endregion
    }
}
