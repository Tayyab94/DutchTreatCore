using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.ViewModels
{
    public class OrderViewModel
    {
        public int  orderId { get; set; }
        public DateTime orderDate { get; set; }

        [Required]
        [MinLength(4,ErrorMessage = "min lenght is 4")]
        public string orderNumber { get; set; }
    }
}
