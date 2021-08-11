using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceProduto : IServiceProduct
    {

        private readonly IProduct _IProd;

        public ServiceProduto(IProduct ok)
        {
            _IProd = ok;
        }

        public async Task AddProduct(Product product)
        {
            var validarNome = product.ValidarPropriedadeString(product.Nome, "Nome");

            var validarPreco = product.ValidarPropriedadeDecimal(product.Preco, "Preco");

            if(validarNome && validarPreco)
            {
                product.Ativo = true;
                await _IProd.Add(product);
            }

        }

        public async Task UpdateProduct(Product product)
        {
            var validarNome = product.ValidarPropriedadeString(product.Nome, "Nome");

            var validarPreco = product.ValidarPropriedadeDecimal(product.Preco, "Preco");

            if (validarNome && validarPreco)
            {

                await _IProd.Update(product);
            }
        }
    }
}
