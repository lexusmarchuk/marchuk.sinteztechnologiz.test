using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marchuk.SintezTech.Core.Models
{
    public class SintezCustomer
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
