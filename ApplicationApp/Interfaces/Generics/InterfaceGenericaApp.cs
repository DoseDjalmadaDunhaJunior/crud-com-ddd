using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces.Generics
{
    /// <summary>
    /// Essa classe basicamente mostra a interface (quanto ao o que o banco vai fazer)
    /// para o generic
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface InterfaceGenericaApp<T> where T : class
    {
        Task Add(T Objeto);
        Task Update(T Objeto);
        Task Delete(T Objeto);
        Task<T> GetEntityById(int Id);
        Task<List<T>> List();
    }
}
