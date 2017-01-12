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
        void PlaceOrder(SintezOrder orderRequest);
        SintezOrder GetOrder(int id);
    }
}
