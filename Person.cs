using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookNext
{
    public class Person
    {
        public string[] Array_of_Details = new string[8];
        public Person(string First, string Last, string Add, string City, string State, string Zip, string Phone, string Email)
        {
            Array_of_Details[0] = First;
            Array_of_Details[1] = Last;
            Array_of_Details[2] = Add;
            Array_of_Details[3] = City;
            Array_of_Details[4] = State;
            Array_of_Details[5] = Zip;
            Array_of_Details[6] = Phone;
            Array_of_Details[7] = Email;
        }
        public void Check()
        {
            Console.WriteLine("\nThe details for {0} {1} are:\nAddress: {2}\nCity: {3}\nState: {4}\n" +
                "Zip Code: {5}\nPhone Number: {6}\nEmail: {7}\n", Array_of_Details[0],
                Array_of_Details[1], Array_of_Details[2], Array_of_Details[3],
                Array_of_Details[4], Array_of_Details[5], Array_of_Details[6], Array_of_Details[7]);
        }

    }
}


