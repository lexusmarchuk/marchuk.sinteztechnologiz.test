using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public SintezCustomer CustomerInfo { get; set; }

        /// <summary>
        /// Order Products.
        /// </summary>
        [Required]
        public IEnumerable<SintezOrderProduct> Products { get; set; }

        /// <summary>
        /// Shipment Inormation.
        /// </summary>
        [Required]
        public SintezOrderShipmentInfo ShipTo { get; set; }
    }
}
