using Marchuk.SintezTech.Core.Models;
using Marchuk.SintezTech.Models;
using Marchuk.SintezTech.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marchuk.SintezTech.Core.Interfaces
{
    public interface IProductService
    {
        void AddProduct(SintezProduct model);
        SintezProduct Get(int id);
        IEnumerable<SintezProduct> GetAll();               
    }
}
