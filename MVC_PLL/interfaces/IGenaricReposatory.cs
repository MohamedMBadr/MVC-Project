using MVC.DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BLL.interfaces
{
    public interface IGenaricReposatory<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
         
        Task <T> Get(int id);
            

        Task Add(T item);

        void Update(T item);
            
        void Delete(T item);


    }

}
