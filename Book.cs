using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBooks
{
    public class Book
    {
        public static List<AddressContacts> People = new List<AddressContacts>();

        public static void AddPerson()
        {
            AddressContacts contacts = new AddressContacts();
            int choice1 = 0;
            Console.WriteLine("Input any one operation you want to perform: ");
            Console.WriteLine("1.Add Person\n2.Edit Person\n3.Delete Person");
            choice1 = Convert.ToInt32(Console.ReadLine());

            switch (choice1)
            {
                // Case 1 for add 
                case 1:
                    Console.WriteLine("Enter First Name:");
                    contacts.First_name = Console.ReadLine();
                    Console.WriteLine("Enter Last Name:");
                    contacts.Last_name = Console.ReadLine();
                    Console.WriteLine("Enter Address:");
                    contacts.Address = Console.ReadLine();
                    Console.WriteLine("Enter State:");
                    contacts.State = Console.ReadLine();
                    Console.WriteLine("Enter City:");
                    contacts.City = Console.ReadLine();
                    Console.WriteLine("Enter Zip:");
                    contacts.Zip = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Phone Number:");
                    contacts.Phone_number = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Enter Email:");
                    contacts.Email = Console.ReadLine();

                    People.Add(contacts);
                    Console.WriteLine("Contact Added Successfully:");

                    break;

                // Case 2 for edit 
                case 2:
                    string name;
                    int choice = 0;
                    Console.WriteLine("Enter First Name of Contact to edit: ");
                    name = Console.ReadLine();
                    for (int i = 0; i < People.Count; i++)
                    {
                        AddressContacts contact = People[i];
                        Console.WriteLine("Info of selected Person");
                        //showing person's info to user for clarification
                        PrintPerson(contact);
                        //Console.WriteLine("Press Enter");
                        //Console.ReadLine();


                        if (contact.First_name == name)
                        {
                            Console.WriteLine("Now choose what you want to edit");

                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("1.First Name\n2.Last Name\n3.Address\n4.State\n5.City\n6.Zip\n7.Phone Number\n8.Email");
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("Input Here: ");
                            choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("Enter First Name:");
                                    contact.First_name = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.WriteLine("Enter Last Name:");
                                    contact.Last_name = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.WriteLine("Enter Address:");
                                    contact.Address = Console.ReadLine();
                                    break;
                                case 4:
                                    Console.WriteLine("Enter State:");
                                    contact.State = Console.ReadLine();
                                    break;
                                case 5:
                                    Console.WriteLine("Enter City:");
                                    contact.City = Console.ReadLine();
                                    break;
                                case 6:
                                    Console.WriteLine("Enter Zip:");
                                    contact.Zip = Convert.ToInt32(Console.ReadLine());
                                    break;
                                case 7:
                                    Console.WriteLine("Enter Phone Number:");
                                    contact.Phone_number = Convert.ToInt64(Console.ReadLine());
                                    break;
                                case 8:
                                    Console.WriteLine("Enter Email:");
                                    contact.Email = Console.ReadLine();
                                    break;
                                default:
                                    Console.WriteLine("Enter Valid Number");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No match found");
                        }
                    }
                    break;

                // Case 3 for delete ( additional feature UC-4 )
                case 3:
                    string name1;
                    Console.WriteLine("Enter Name you want to remove: ");
                    name1 = Console.ReadLine();
                    for (int i = 0; i < People.Count; i++)
                    {
                        AddressContacts contact = People[i];
                        //PrintPerson(contact);

                        if (contact.First_name == name1)
                        {
                            People.RemoveAt(i);
                            Console.WriteLine(contact.First_name + " is Removed!..");
                        }
                    }
                    break;
            }

        }
        // method to preview or display information
        private static void PrintPerson(AddressContacts person)
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("First Name: " + person.First_name);
            Console.WriteLine("Last Name: " + person.Last_name);
            Console.WriteLine("Address: " + person.Address);
            Console.WriteLine("State: " + person.State);
            Console.WriteLine("City: " + person.City);
            Console.WriteLine("Zip: " + person.Zip);
            Console.WriteLine("Phone Number: " + person.Phone_number);
            Console.WriteLine("Email: " + person.Email);
            Console.WriteLine("-------------------------------------------");
        }
        public static void ListPeople()
        {
            foreach (var contacts in People)
            {
                PrintPerson(contacts);
            }
        }
    }
}
