using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marchuk.SintezTech.Core.Models
{
    /// <summary>
    /// Sintez Product class.
    /// </summary>
    public class SintezProduct
    {
        /// <summary>
        /// Product Id.
        /// </summary>
        public int Id { get; set; }

        [Required]
        /// <summary>
        /// Product Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product Price.
        /// </summary>
        [Required]
        public float Price { get; set; }
    }
}
