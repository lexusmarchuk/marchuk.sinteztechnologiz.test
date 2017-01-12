using Marchuk.SintezTech.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marchuk.SintezTech.Models.Interfaces
{
    public interface IGenericRepository<T>
    {
        void Add(T product);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
