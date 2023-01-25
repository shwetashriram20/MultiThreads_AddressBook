namespace AddressBookNext
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            AddressBooks Relatives = new AddressBooks();
            AddressBooks Work = new AddressBooks();
            int Control;
            do
            {
                Console.WriteLine("\nChoose an Address Book: ");
                Console.WriteLine("1 for Relatives Address book");
                Console.WriteLine("2 for Work Address Book");
                Console.WriteLine("3 to Search across all Address books");
                Console.WriteLine("4 to View contacts in a City or State");
                Console.WriteLine("0 to EXIT");
                Control = Convert.ToInt32(Console.ReadLine());
                switch (Control)
                {
                    case 1:
                        Relatives.Access_to_Addressbook();
                        break;
                    case 2:
                        Work.Access_to_Addressbook();
                        break;
                    case 3:
                        Console.Write("Search by (City/State): ");
                        string cityOrState = Console.ReadLine().ToLower();
                        string name = "";
                        int num = 0;
                        if (cityOrState == "city")
                        {
                            Console.Write("Enter the name of the city: ");
                            name = Console.ReadLine();
                            num = 1;
                        }
                        else if (cityOrState == "state")
                        {
                            Console.Write("Enter the name of the state: ");
                            name = Console.ReadLine();
                            num = 2;
                        }
                        Console.WriteLine("Names of people living in {0} are:\n", name);
                        int result = Relatives.search(name, num) + Work.search(name, num);

                        Console.WriteLine("Number of people in {0} are {1}", name, num);
                        break;
                    case 4:
                        Console.WriteLine("\n1 for Relatives");
                        Console.WriteLine("2 for Work");
                        Console.WriteLine("0 to Exit");
                        Console.Write("Pick an address book: ");
                        int book = Convert.ToInt32(Console.ReadLine());
                        switch (book)
                        {
                            case 1:
                                Relatives.viewContacts();
                                break;
                            case 2:
                                Work.viewContacts();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 0:
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
