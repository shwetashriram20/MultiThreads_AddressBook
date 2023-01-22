namespace AddressBookNext
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            bool choice = true;
            AddressBook Adr = new AddressBook();
            details();

            static void UserChoice()
            {
                Console.WriteLine("Choose one of the following options: ");
                Console.WriteLine("#1 Create new user");
                Console.WriteLine("#2 Edit user information");
                Console.WriteLine("#3 Delete existing user");
                Console.WriteLine("#4 Show all users in adressBook");
                Console.WriteLine("#5 Exit");
            }
            while (choice)
            {
                UserChoice();
                int Choice = Convert.ToInt32(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        details();
                        Adr.printUser();
                        break;
                    case 2:
                        Adr.editContact();
                        Adr.printUser();
                        break;
                    case 3:
                        Adr.deleteContact();
                        Adr.printUser();
                        break;
                    case 4:
                        Adr.printUser();
                        break;
                    case 5:
                        choice = false;
                        break;
                    default:
                        Console.WriteLine("Enter a valid option");
                        break;

                }
            }
            static void details()
            {
                AddressBook Adr = new AddressBook();
                Console.WriteLine("Enter FirstName:");
                string FirstName = Console.ReadLine();

                Console.WriteLine("Enter LastName:");
                string LastName = Console.ReadLine();

                Console.WriteLine("Enter Address:");
                string Address = Console.ReadLine();

                Console.WriteLine("Enter City:");
                string City = Console.ReadLine();

                Console.WriteLine("Enter State:");
                string State = Console.ReadLine();

                Console.WriteLine("Enter Zip:");
                string ZipCode = Console.ReadLine();

                Console.WriteLine("Enter PhoneNum:");
                string PhoneNum = Console.ReadLine();

                Console.WriteLine("Enter Email:");
                string EmailId = Console.ReadLine();
                Adr.createUser(FirstName, LastName, Address, City, State, ZipCode, PhoneNum, EmailId);
            }
        }
    }
}