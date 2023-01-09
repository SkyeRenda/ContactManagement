using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Models
{
    internal class Contact
    {
        public string Name { get; set; } ="";
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string Region { get; set; } = "";
        public int PostalCode { get; set; } = 0;
        public string Country { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Fax { get; set; } = "";

        public string emailAddress { get; set; } = "";
    }
}
