using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Models
{
    internal class Contact
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; } ="";
        public string Surname { get; set; } = "";
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string Region { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public string Country { get; set; } = "";
        public string Phone { get; set; } = "";
        public string EmailAddress { get; set; } = "";

        public string ContactGroup { get; set; } = "";
        public Contact(int id, string? name, string? surname, string? address, string? city, string? region, string? postalCode, string? country, string? phone, string? emailAddress, string? contactGroup) {
            this.ID = id;
            Name = (name ==null) ? "" : name;
            Surname = (surname == null) ? "" : surname; 
            Address = (address == null) ? "" : address; 
            City = (city == null) ? "" : city; 
            Region = (region == null) ? "" : region;
            PostalCode = (postalCode == null) ? "" : postalCode; 
            Country = (country == null) ? "" : country;
            Phone = (phone == null) ? "" : phone;
            EmailAddress = (emailAddress == null) ? "" : emailAddress; 
            ContactGroup = (contactGroup == null) ? "" : contactGroup;

        }
        public Contact(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
