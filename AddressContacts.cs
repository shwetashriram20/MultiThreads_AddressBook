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
        public string First_name { get; set; }
        public string Last_name { get; set; }

        public string Address { get; set; }
        public string State { get; set; }

        public string City { get; set; }

        public int Zip { get; set; }
        public long Phone_number { get; set; }

        public string Email { get; set; }
    }

}
