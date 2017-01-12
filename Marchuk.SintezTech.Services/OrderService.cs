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
    public class OrderService : IOrderService
    {
        private IGenericRepository<SintezOrder> _repository { get; set; }

        public OrderService(IGenericRepository<SintezOrder> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Returns order details.
        /// </summary>
        /// <param name="id">Order Id.</param>
        /// <returns>SintezOrder object.</returns>
        public SintezOrder GetOrder(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Order Id can't be negative.");
            }

            return this._repository.Get(id);
        }

        /// <summary>
        /// Submits Order.
        /// </summary>
        /// <param name="orderRequest">Order to Submit.</param>
        public void PlaceOrder(SintezOrder orderRequest)
        {
            this.ValidateOrder(orderRequest);

            this._repository.Add(orderRequest);
        }

        /// <summary>
        /// Validates Order for submit.
        /// </summary>
        /// <param name="orderRequest">Order to Submit.</param>
        private void ValidateOrder(SintezOrder orderRequest)
        {
            if (orderRequest == null)
            {
                throw new ArgumentNullException(nameof(orderRequest));
            }

            if (orderRequest.CustomerInfo == null)
            {
                throw new ArgumentNullException(nameof(orderRequest.CustomerInfo));
            }

            if (string.IsNullOrWhiteSpace(orderRequest.CustomerInfo.FullName))
            {
                throw new ArgumentException(nameof(orderRequest.CustomerInfo.FullName));
            }

            if (orderRequest.Products == null)
            {
                throw new ArgumentNullException(nameof(orderRequest.Products));
            }

            if (orderRequest.Products.Count() == 0)
            {
                throw new Exception("There are no products in order.");
            }

            if (orderRequest.ShipTo == null)
            {
                throw new ArgumentNullException(nameof(orderRequest.ShipTo));
            }

            if (string.IsNullOrWhiteSpace(orderRequest.ShipTo.ShipToAddress))
            {
                throw new ArgumentException(nameof(orderRequest.ShipTo.ShipToAddress));
            }
        }
    }
}
