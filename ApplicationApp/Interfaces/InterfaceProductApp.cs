using ApplicationApp.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{

    /// <summary>
    /// Essa classe é a interface do produto, ela herda a classe generica mais acima
    /// por conta disso ela é mais facil de ser implementada
    /// </summary>
    public interface InterfaceProductApp : InterfaceGenericaApp<Product>
    {

        Task AddProduct(Product product);

        Task UpdateProduct(Product product);

    }
}
