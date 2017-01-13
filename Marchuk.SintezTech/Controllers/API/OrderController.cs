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
    public class OrderController : ApiController
    {
        private IOrderService _service = null;

        public OrderController(IOrderService service)
        {
            this._service = service;
        }

        // GET: api/Order
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/Order/5
        public SintezOrder Get(int id)
        {
            return this._service.GetOrder(id);
        }

        // POST: api/Order
        public int Post([FromBody]SintezOrder model)
        {
            int id = -1;

            if (ModelState.IsValid)
            {
                id = this._service.PlaceOrder(model);
            }

            return id;
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]SintezOrder value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Order/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
