using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopingRest_Controller.Manager
{
    public interface IManagerDB<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetAllByName(string name);

        Task<T> GetById(int id);

        Task Create(T item);

        Task Update(int id, T item);

        Task Delete(int id);
    }
}
