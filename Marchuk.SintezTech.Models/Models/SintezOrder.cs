using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marchuk.SintezTech.Core.Models
{
    /// <summary>
    /// Submit Order class.
    /// </summary>
    public class SintezOrder
    {
        public int Id { get; set; }

        /// <summary>
        /// Customer Information.
        /// </summary>
        public SintezCustomer CustomerInfo { get; set; }

        /// <summary>
        /// Order Products.
        /// </summary>
        public IEnumerable<SintezOrderProduct> Products { get; set; }

        /// <summary>
        /// Shipment Inormation.
        /// </summary>
        public SintezOrderShipmentInfo ShipTo { get; set; }
    }
}
