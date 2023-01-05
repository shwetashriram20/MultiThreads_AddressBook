using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBooks
{
    class Book
        {
            private List<AddressContacts> addressBookList = new List<AddressContacts>();
            public List<AddressContacts> AddressBookList
            {
                get { return addressBookList; }
                set { this.addressBookList = value; }
            }
            public Book()
            {
                AddressBookList = new List<AddressContacts>();
            }

            public void User()
            {
                Console.WriteLine("Enter FirstName:");
                var FirstName = Console.ReadLine();

                Console.WriteLine("Enter LastName:");
                var LastName = Console.ReadLine();

                Console.WriteLine("Enter Address:");
                var Address = Console.ReadLine();

            Console.WriteLine("Enter City:");
            var City = Console.ReadLine();

            Console.WriteLine("Enter State:");
            var State = Console.ReadLine();

            Console.WriteLine("Enter Zip:");
            var Zip = Console.ReadLine();

            Console.WriteLine("Enter PhoneNum:");
            var PhoneNum = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            var Email = Console.ReadLine();

            AddressContacts contact = new AddressContacts(FirstName, LastName, Address, City, State, Zip, PhoneNum, Email);
            AddPersonToList(contact);

        }
        private void AddPersonToList(AddressContacts contact) => AddressBookList.Add(contact);
        public void ShowPersonsList()
        {
            foreach (var person in AddressBookList)
            {
                Console.WriteLine("\n");
                Console.WriteLine("FirstName: {0}, LastName: {1}, Adress: {2}, City : {3}, State: {4}, Zip: {5}, PhoneNum: {6}, Email: {7}", person.FirstName, person.LastName, person.Address, person.City, person.State, person.Zip, person.PhoneNumber, person.Email);
            }
            Console.ReadLine();
        }
        public void EditUserInformation()
        {
            Console.WriteLine("Which information do you want to Edit?");
            Console.WriteLine("#1: Firstname, #2: Lastname, 3#: Address, 4#: City, 5#: State, 6#: Zip, 7#: PhoneNumber, 8#: Email");
            var userOption = Console.ReadLine();

            Console.WriteLine("Enter firstname of existing user to be updated");
            var oldFirstName = Console.ReadLine();
            EditUserFunction(userOption, oldFirstName);
        }

        private void EditUserFunction(string userOption, string oldFirstName)
        {
            var personsWithMatchingFirstName = AddressBookList.Where(contact => contact.FirstName == oldFirstName);
            string newValue;

            if (userOption == "1")
            {
                Console.WriteLine("Enter a new first Name");
                newValue = Console.ReadLine();

                foreach (var contact in personsWithMatchingFirstName)
                {
                    contact.FirstName = newValue;
                }
            }
            else if (userOption == "2")
            {
                Console.WriteLine("Enter a new last name");
                newValue = Console.ReadLine();

                foreach (var contact in personsWithMatchingFirstName)
                {
                    contact.LastName = newValue;
                }
            }
            else if (userOption == "3")
            {
                Console.WriteLine("Enter a new address");
                newValue = Console.ReadLine();

                foreach (var contact in personsWithMatchingFirstName)
                {
                    contact.Address = newValue;
                }
            }
            else if (userOption == "4")
            {
                Console.WriteLine("Enter a new City Name");
                newValue = Console.ReadLine();

                foreach (var contact in personsWithMatchingFirstName)
                {
                    contact.City = newValue;
                }
            }
            else if (userOption == "5")
            {
                Console.WriteLine("Enter a new State Name");
                newValue = Console.ReadLine();

                foreach (var contact in personsWithMatchingFirstName)
                {
                    contact.State = newValue;
                }
            }
            else if (userOption == "6")
            {
                Console.WriteLine("Enter a new Zip code");
                newValue = Console.ReadLine();

                foreach (var contact in personsWithMatchingFirstName)
                {
                    contact.Zip = newValue;
                }
            }
            else if (userOption == "7")
            {
                Console.WriteLine("Enter a new PhoneNum");
                newValue = Console.ReadLine();

                foreach (var contact in personsWithMatchingFirstName)
                {
                    contact.PhoneNumber = newValue;
                }
            }
            else if (userOption == "8")
            {
                Console.WriteLine("Enter a new Email");
                newValue = Console.ReadLine();

                foreach (var contact in personsWithMatchingFirstName)
                {
                    contact.Email = newValue;
                }
            }
        }
    }
}

    

