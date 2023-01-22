namespace AddressBookNext
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");

            bool choice = true;

            AddressBooks Adr = new AddressBooks();
            Adr.createUser();

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
                        Adr.createUser();
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
        }
    }
}