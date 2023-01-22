using AddressBookNext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookNext
{
    public interface AddressBookSystem
    {
        //  void createUser();
        void printUser();
        void editContact();
        void deleteContact();
    }
    public class AddressBook : AddressBookSystem
    {
        public static List<Person> People = new List<Person>();
        public void createUser(string FirstName, string LastName, string Address, string City, string State, string ZipCode, string PhoneNum, string EmailId)
        {
            Person person = new Person(FirstName, LastName, Address, City, State, ZipCode, PhoneNum, EmailId);

            if (People.Count == 0)
            {
                People.Add(person);
            }
            else
            {
                Person people = People.Find(a => a.FirstName.Equals(FirstName));
                if (people == null)
                {
                    Person p = new Person(FirstName, LastName, Address, City, State, ZipCode, PhoneNum, EmailId);
                    People.Add(p);
                }
                else
                {
                    Console.WriteLine("-------Record is already exists-------");
                    Console.WriteLine("Modify the details which has duplicate name");
                    editContact();
                }
            }
        }
        public void printUser()
        {
            if (People.Count == 0)
            {
                Console.WriteLine("Your address book is empty.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("\nHere are the current {0} people in your address book:\n", People.Count);
            foreach (var person in People)
            {
                Console.WriteLine(" FirstName: {0},\n LastName: {1},\n Adress: {2},\n City : {3},\n State: {4},\n Zip: {5},\n PhoneNum: {6},\n Email: {7}", person.FirstName, person.LastName, person.Address, person.City, person.State, person.ZipCode, person.PhoneNum, person.EmailId);
                Console.WriteLine("________________________________");
            }
        }
        public void editContact()
        {
            if (People.Count != 0)
            {
                Console.WriteLine("Enter the First Name of contact For editing details:");
                string Modified = Console.ReadLine();
                foreach (var person in People)
                {
                    if (person.FirstName.ToUpper() == Modified.ToUpper())
                    {
                        while (true)
                        {
                            Console.WriteLine("Which information do you want to Edit?");
                            Console.WriteLine("#1: Firstname, #2: Lastname, 3#: Address, 4#: City, 5#: State, 6#: Zipcode, 7#: PhoneNum, 8#: EmailId, 9#: Exit");
                            int userOption = Convert.ToInt32(Console.ReadLine());
                            switch (userOption)
                            {
                                case 1:
                                    Console.WriteLine("Enter the New First Name: ");
                                    person.FirstName = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.WriteLine("Enter the New Last Name: ");
                                    person.LastName = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.WriteLine("Enter the New Address: ");
                                    person.Address = Console.ReadLine();
                                    break;
                                case 4:
                                    Console.WriteLine("Enter the New City: ");
                                    person.City = Console.ReadLine();
                                    break;
                                case 5:
                                    Console.WriteLine("Enter the New State: ");
                                    person.State = Console.ReadLine();
                                    break;
                                case 6:
                                    Console.WriteLine("Enter the New Pin Code: ");
                                    person.ZipCode = Console.ReadLine();
                                    break;
                                case 7:
                                    Console.WriteLine("Enter the New Phone Number: ");
                                    person.PhoneNum = Console.ReadLine();
                                    break;
                                case 8:
                                    Console.WriteLine("Enter the New Phone Number: ");
                                    person.PhoneNum = Console.ReadLine();
                                    break;
                                case 9:
                                    return;

                            }

                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter the valid name!");
            }
        }
        public void deleteContact()
        {
            Console.WriteLine("Enter the first name of the person you would like to remove.");
            string Remove = Console.ReadLine();
            foreach (var person in People.ToList())
            {
                if (person.FirstName.ToUpper() == Remove.ToUpper())
                {
                    People.Remove(person);
                    Console.WriteLine("Contact is deleted");
                }
                else
                {
                    Console.WriteLine("Contact is not present");
                }
            }
        }
        public void searchperson()
        {
            Console.WriteLine("how you would like to search.");
            Console.WriteLine("#1: using city\n #2: using state");
            string inp = Console.ReadLine();

            switch (inp)
            {
                case "1":
                    {
                        Console.WriteLine("Enter city : ");
                        string city = Console.ReadLine();
                        foreach (var i in People)
                        {
                            Person forcity = People.Find(a => i.City.Equals(city));
                            if (forcity == null)
                            {
                                Console.WriteLine("Match not fund");
                            }
                            else
                            {
                                Console.WriteLine("match found\n");

                                Console.WriteLine("Neme of person is {0} {1}.\n", i.FirstName, i.LastName);
                                Console.WriteLine("Details of person\n");
                                Console.WriteLine(" FirstName: {0},\n LastName: {1},\n Adress: {2},\n City : {3},\n State: {4},\n Zip: {5},\n PhoneNum: {6},\n Email: {7}", i.FirstName, i.LastName, i.Address, i.City, i.State, i.ZipCode, i.PhoneNum, i.EmailId);
                                Console.WriteLine("-----------------------------------------------------------------");
                                Console.WriteLine();

                            }
                        }
                        break;
                    }

                case "2":

                    {
                        Console.WriteLine("Enter state : ");
                        string state = Console.ReadLine();
                        foreach (var i in People)
                        {
                            Person forstate = People.Find(a => i.State.Equals(state));
                            if (forstate == null)
                            {
                                Console.WriteLine("Match not fund");
                            }
                            else
                            {
                                Console.WriteLine("match found\n");

                                Console.WriteLine("Neme of person is {0} {1}.", i.FirstName, i.LastName + "\n");
                                Console.WriteLine("Details of person\n");
                                Console.WriteLine(" FirstName: {0},\n LastName: {1},\n Adress: {2},\n City : {3},\n State: {4},\n Zip: {5},\n PhoneNum: {6},\n Email: {7}", i.FirstName, i.LastName, i.Address, i.City, i.State, i.ZipCode, i.PhoneNum, i.EmailId);
                                Console.WriteLine("-----------------------------------------------------------------");
                                Console.WriteLine();
                            }
                        }
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Enter valid input!");
                        break;
                    }
            }
        }
        public void countperson()
        {
            Console.WriteLine("\nHere are the current {0} contacts in your address book:\n", People.Count);
        }
    }
}