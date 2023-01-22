using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookNext
{
    public class Person
    {
        public string FirstName;
        public string LastName;
        public string PhoneNumber;
        public string Address;
        public string City;
        public string State;
        public string ZipCode;
        public string PhoneNum;
        public string EmailId;
        public Person(string FirstName, string LastName, string Address, string City, string State, string ZipCode, string PhoneNum, string EmailId)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.City = City;
            this.State = State;
            this.ZipCode = ZipCode;
            this.PhoneNum = PhoneNum;
            this.EmailId = EmailId;
        }

    }
}