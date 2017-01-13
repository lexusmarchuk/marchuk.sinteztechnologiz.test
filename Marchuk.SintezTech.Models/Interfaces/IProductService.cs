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
        /// <summary>
        /// Adds new Product.
        /// </summary>
        /// <param name="sintezProduct">Product details.</param>
        /// <returns>New Product Id.</returns>
        int AddProduct(SintezProduct model);

        /// <summary>
        /// Returns Product info.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <returns>SintezProduct object</returns>
        SintezProduct Get(int id);

        /// <summary>
        /// Returns set of Products.
        /// </summary>
        /// <returns>IEnumerable of SintezProduct</returns>
        IEnumerable<SintezProduct> GetAll();               
    }
}
