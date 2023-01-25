using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookNext
{
    public class AddressBooks
    {

        Dictionary<string, string[]> Page = new Dictionary<string, string[]>();
        List<string> persons = new List<string>();
        Dictionary<string, List<string>> cityPerson = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> statePerson = new Dictionary<string, List<string>>();

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
            if (!cityPerson.Keys.Contains(City.ToLower()))
            {
                persons.Add(First_Name);
                cityPerson.Add(City.ToLower(), persons);
                persons.Clear();
            }
            else
            {
                cityPerson.TryGetValue(City.ToLower(), out persons);
                if (!persons.Contains(First_Name))
                    persons.Add(First_Name);
                cityPerson.Remove(City.ToLower());
                cityPerson.Add(City.ToLower(), persons);
                persons.Clear();
            }
            if (!statePerson.Keys.Contains(State.ToLower()))
            {
                persons.Add(First_Name);
                statePerson.Add(State.ToLower(), persons);
                persons.Clear();
            }
            else
            {
                statePerson.TryGetValue(State.ToLower(), out persons);
                if (!persons.Contains(First_Name))
                    persons.Add(First_Name);
                statePerson.Remove(State.ToLower());
                statePerson.Add(State.ToLower(), persons);
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
            Record.Check();
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
        public void SortAlphabatically()
        {
            List<string> keys = new List<string>(Page.Keys);
            keys.Sort();
            foreach (string key in keys)
            {
                Display(key);
            }
        }
        public void Access_to_Addressbook()
        {
            int Control;
            do
            {
                Console.WriteLine("\n1 to Add Contacts");
                Console.WriteLine("2 to Edit Contacts");
                Console.WriteLine("3 to Delete Contacts");
                Console.WriteLine("4 to Display Contacts");
                Console.WriteLine("5 to Sort the address book");
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
                    default:
                        Console.WriteLine("Invalid Entry");
                        break;
                }
            } 
            while (Control != 0);
        }
    }
}

