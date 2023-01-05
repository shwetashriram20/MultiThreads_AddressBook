using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBooks
{
    public class AddressContacts
    {
        public string FirstName;
        public string LastName;
        public string Address;
        public string City;
        public string State;
        public string Zip;
        public string PhoneNumber;
        public string Email;
        public AddressContacts(string FirstName, string LastName, string Address, string City, string State, string Zip, string PhoneNumber, string Email)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.City = City;
            this.State = State;
            this.Zip = Zip;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
        }

    }
}
