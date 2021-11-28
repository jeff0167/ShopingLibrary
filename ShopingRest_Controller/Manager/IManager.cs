using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopingRest_Controller.Manager
{
    public interface IManager<T>
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetAllByName(string name);

        T GetById(int id);

        void Create(T item);

        void Update(int id, T item);

        void Delete(int id);
    }
}
