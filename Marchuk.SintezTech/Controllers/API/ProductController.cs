using Marchuk.SintezTech.Core.Interfaces;
using Marchuk.SintezTech.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marchuk.SintezTech.Controllers.API
{
    public class ProductController : ApiController
    {
        private IProductService _productService = null;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        // GET: api/Product
        public IEnumerable<SintezProduct> Get()
        {
            return this._productService.GetAll();
        }

        // GET: api/Product/5
        public SintezProduct Get(int id)
        {
            return this._productService.Get(id);
        }

        // POST: api/Product
        public void Post([FromBody]SintezProduct model)
        {
            if (ModelState.IsValid)
            {
                this._productService.AddProduct(model);
            }
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]SintezProduct value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
