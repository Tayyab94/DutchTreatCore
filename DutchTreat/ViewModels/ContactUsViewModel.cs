using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.ViewModels
{
    public class ContactUsViewModel
    {

        [Required]
        public string  Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(7,ErrorMessage = "length should be 3 to 7",MinimumLength = 3)]
        public string Password { get; set; }

        public bool ChkBox { get; set; }
    }
}
