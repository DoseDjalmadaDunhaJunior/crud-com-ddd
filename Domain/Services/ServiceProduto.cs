using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    /// <summary>
    /// As funções aqui fazem as validações para se for tudo ok salvar no banco de dados
    /// No caso no AddProduct e no UpdateProduct
    /// </summary>
    public class ServiceProduto : IServiceProduct
    {

        private readonly IProduct _IProd;

        /// <summary>
        /// A função abaixo foi criada, ela é o construtor da classe
        /// </summary>
        /// <param name="ok"></param>
        public ServiceProduto(IProduct ok)
        {
            _IProd = ok;
        }

        /// <summary>
        /// A função abaixo só deixa adicionar um produto se ele for maior que zero e se existir uma descrição dele
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Essa função permite alterar apenas um ou outro, podendo se for o caso manter o dado antigo
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
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
