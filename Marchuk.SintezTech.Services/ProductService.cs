using Marchuk.SintezTech.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marchuk.SintezTech.Core.Models;
using Marchuk.SintezTech.Models.Interfaces;

namespace Marchuk.SintezTech.Services
{
    public class ProductService : IProductService
    {
        private IGenericRepository<SintezProduct> _repository { get; set; }

        public ProductService(IGenericRepository<SintezProduct> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Adds new Product.
        /// </summary>
        /// <param name="sintezProduct">Product details.</param>
        public int AddProduct(SintezProduct sintezProduct)
        {
            if (sintezProduct == null)
            {
                throw new ArgumentNullException(nameof(sintezProduct));
            }

            if (string.IsNullOrWhiteSpace(sintezProduct.Name))
            {
                throw new ArgumentException(nameof(sintezProduct.Name));
            }

            return this._repository.Add(sintezProduct);
        }

        /// <summary>
        /// Returns Product info.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <returns>SintezProduct object</returns>
        public SintezProduct Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Product Id can't be negative.");
            }

            return this._repository.Get(id);
        }

        /// <summary>
        /// Returns set of Products.
        /// </summary>
        /// <returns>IEnumerable of SintezProduct</returns>
        public IEnumerable<SintezProduct> GetAll()
        {
            return this._repository.GetAll();
        }
    }
}
