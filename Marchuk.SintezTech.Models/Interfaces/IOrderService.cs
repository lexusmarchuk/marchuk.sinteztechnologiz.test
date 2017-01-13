using Marchuk.SintezTech.Core.Models;
using Marchuk.SintezTech.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marchuk.SintezTech.Core.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Submits Order.
        /// </summary>
        /// <param name="orderRequest">Order to Submit.</param>
        /// <returns>New Order Id.</returns>
        int PlaceOrder(SintezOrder orderRequest);

        /// <summary>
        /// Returns order details.
        /// </summary>
        /// <param name="id">Order Id.</param>
        /// <returns>SintezOrder object.</returns>
        SintezOrder GetOrder(int id);
    }
}
