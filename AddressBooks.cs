using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AddressBookNext
{
    public class AddressBooks
    {
        public class AddressBook
        {

            Dictionary<string, string[]> Page = new Dictionary<string, string[]>();
            List<string> persons = new List<string>();
            Dictionary<string, List<string>> cityPerson = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> statePerson = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> zipPerson = new Dictionary<string, List<string>>();
            ExternalOperations external;

            public AddressBook(string FileName)
            {
                external = new(FileName, Page);
            }

            public void AddAddress()
            {
                string First_Name;
                try
                {
                    Console.Write("Enter First Name: ");
                    First_Name = Console.ReadLine();
                }
                catch (ArgumentNullException)
                {
                    throw new ArgumentNullException("First name can not be null.");
                }
                if (checkDuplicate(First_Name))
                    throw new Exception("Another person by the same name exists in the Address Book");
                Console.Write("Enter Last Name: ");
                string Last_Name = Console.ReadLine();
                Console.Write("Enter Address: ");
                string Address = Console.ReadLine();
                Console.Write("Enter City: ");
                string City = Console.ReadLine();
                Console.Write("Enter State: ");
                string State = Console.ReadLine();
                Console.Write("Enter Zip : ");
                string Zip_Code = Console.ReadLine();
                Console.Write("Enter Phone Number: ");
                string Phone_Number = Console.ReadLine();
                Console.Write("Enter Email Address: ");
                string Email = Console.ReadLine();

                Person Record = new Person(First_Name, Last_Name, Address, City, State, Zip_Code, Phone_Number, Email);

                Page.Add(First_Name, Record.Array_of_Details);

                Record.Check();

                SaveInOtherDictionaries(cityPerson, First_Name, City);
                SaveInOtherDictionaries(statePerson, First_Name, State);
                SaveInOtherDictionaries(zipPerson, First_Name, Zip_Code);
            }
            public void SaveInOtherDictionaries(Dictionary<string, List<string>> dict, string First_Name, string PlaceIdentifier)
            {
                if (!dict.Keys.Contains(PlaceIdentifier.ToLower()))
                {
                    persons.Add(First_Name);
                    dict.Add(PlaceIdentifier.ToLower(), persons);
                    persons.Clear();
                }
                else
                {
                    dict.TryGetValue(PlaceIdentifier.ToLower(), out persons);
                    if (!persons.Contains(First_Name))
                        persons.Add(First_Name);
                    dict.Remove(PlaceIdentifier.ToLower());
                    dict.Add(PlaceIdentifier.ToLower(), persons);
                    persons.Clear();
                }
            }

            public bool checkDuplicate(string name) => (Page.ContainsKey(name)) ? true : false;
            public void Edit()
            {
                Console.Write("\nEnter the first name for the contact: ");
                string First_Name = Console.ReadLine();
                if (!Page.ContainsKey(First_Name))

                    throw new ArgumentNullException("No such person in the Addressbook");

                Page.TryGetValue(First_Name, out string[] Edit_Detail);

                Console.Write("Enter a number to edit first name(1), last name(2), address(3), " +
                    "city(4), state(5), zip code(6), \nphone number(7) or email(8): ");

                int Index = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the new value: ");

                Edit_Detail[Index - 1] = Console.ReadLine();

                Person Record = new Person(
                    Edit_Detail[0], Edit_Detail[1],
                    Edit_Detail[2], Edit_Detail[3],
                    Edit_Detail[4], Edit_Detail[5],
                    Edit_Detail[6], Edit_Detail[7]);

                Page.Remove(First_Name);
                Page.Add(Edit_Detail[0], Edit_Detail);

                Record.Check();
            }
            public void Delete()
            {
                Console.Write("\nEnter the first name for the contact: ");
                string First_Name = Console.ReadLine();
                if (!Page.ContainsKey(First_Name))

                    throw new ArgumentNullException("No such person in the Addressbook");

                Page.TryGetValue(First_Name, out string[] Edit_Detail);
                Page.Remove(First_Name);

                Console.WriteLine("Address entry for {0} {1} was removed.", Edit_Detail[0], Edit_Detail[1]);
            }
            public void Display()
            {
                Console.Write("\nEnter the First name of the contact you want to display (\"all\" to " +
                    "disdplay all contacts): ");
                string Name = Console.ReadLine();
                if (Name != "all")
                {
                    Display(Name);
                }
                else
                {
                    foreach (string Key in Page.Keys)
                    {
                        Display(Key);
                    }
                }
            }
            public void Display(string Name)
            {
                Page.TryGetValue(Name, out string[] Edit_Detail);
                Person Record = new Person(
                    Edit_Detail[0], Edit_Detail[1],
                    Edit_Detail[2], Edit_Detail[3],
                    Edit_Detail[4], Edit_Detail[5],
                    Edit_Detail[6], Edit_Detail[7]);

            }
            public int search(string name, int cityOrState)
            {
                int num = 0;
                foreach (string[] details in Page.Values)
                {
                    if (cityOrState == 1)
                    {
                        Func<string[], bool> InCity = details => details[3].ToLower() == name.ToLower();
                        if (InCity(details))
                        {
                            Console.WriteLine(details[0]);
                            num++;
                        }
                    }
                    else
                    {
                        Func<string[], bool> InState = details => details[4].ToLower() == name.ToLower();
                        if (InState(details))
                        {
                            Console.WriteLine(details[0]);
                            num++;
                        }
                    }
                }
                return num;
            }
            public void viewContacts()
            {
                Console.Write("Search by (City/State): ");
                string cityOrState = Console.ReadLine().ToLower();
                if (cityOrState == "city")
                {
                    Console.Write("Enter the name of the city: ");
                    string city = Console.ReadLine();
                    cityPerson.TryGetValue(city, out persons);
                    foreach (string name in persons)
                        Display(name);
                    persons.Clear();
                }
                else
                {
                    Console.Write("Enter the name of the state: ");
                    string state = Console.ReadLine();
                    statePerson.TryGetValue(state, out persons);
                    foreach (string name in persons)
                        Display(name);
                    persons.Clear();
                }
            }

            public void SortDictionary(Dictionary<string, List<string>> Dict)
            {
                List<string> person = new List<string>();
                persons = new List<string>(Dict.Keys);
                persons.Sort();
                foreach (string PlaceIdentifier in persons)
                {
                    Dict.TryGetValue(PlaceIdentifier, out person);
                    person.Sort();
                    foreach (string name in person)
                        Display(name);
                }
            }

            public void SortAlphabatically()
            {
                List<string> keys = new List<string>(Page.Keys);
                keys.Sort();
                foreach (string key in keys)
                {
                    Display(key);
                }
            }

            public void SortCityStateZip()
            {
                Console.Write("Sort by (City/State/Zip): ");
                string CSorZ = Console.ReadLine();
                switch (CSorZ.ToLower())
                {
                    case "city":
                        SortDictionary(cityPerson);
                        break;
                    case "state":
                        SortDictionary(statePerson);
                        break;
                    case "zip":
                        SortDictionary(zipPerson);
                        break;
                }
            }
            public void Access_to_Addressbooks()
            {
                int Control;
                do
                {
                    Console.WriteLine("\n1 to Add Contacts");
                    Console.WriteLine("2 to Edit Contacts");
                    Console.WriteLine("3 to Delete Contacts");
                    Console.WriteLine("4 to Display Contacts");
                    Console.WriteLine("5 to Sort the address book");
                    Console.WriteLine("6 to Sort the address book by city, state or zip");
                    Console.WriteLine("7 to Manage external .txt file");
                    Console.WriteLine("8 to Manage external CSV file");
                    Console.WriteLine("9 to Manage external JSON file");
                    Console.WriteLine("0 to EXIT");
                    Console.Write("Enter a value: ");
                    Control = Convert.ToInt32(Console.ReadLine());
                    char Confirmation = 'y';
                    switch (Control)
                    {
                        case 0:
                            break;
                        case 1:
                            Console.Write("\nEnter the number of address you want to add: ");
                            int Number = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < Number; i++)
                            {
                                AddAddress();
                            }
                            break;
                        case 2:
                            while (Confirmation == 'y')
                            {
                                Edit();
                                Console.Write("\nEdit another? (y/n): ");
                                Confirmation = Convert.ToChar(Console.ReadLine());
                            }
                            break;
                        case 3:
                            while (Confirmation == 'y')
                            {
                                Delete();
                                Console.Write("\nDelete another? (y/n): ");
                                Confirmation = Convert.ToChar(Console.ReadLine());
                            }
                            break;
                        case 4:
                            while (Confirmation == 'y')
                            {
                                Display();
                                Console.Write("Display another? (y/n): ");
                                Confirmation = Convert.ToChar(Console.ReadLine());
                            }
                            break;
                        case 5:
                            SortAlphabatically();
                            break;
                        case 6:
                            SortCityStateZip();
                            break;
                        case 7:
                            external.TxtHandler();
                            break;
                        case 8:
                            external.CSVHandler();
                            break;
                        case 9:
                            external.JSONHandler();
                            break;
                        default:
                            Console.WriteLine("Invalid Entry");
                            break;
                    }
                }
                while (Control != 0);
            }
        }
    }
}
    


 