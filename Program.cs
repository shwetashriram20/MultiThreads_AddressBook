namespace AddressBooks
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book");

            int choice = 0;
            while (choice != 2)
            {
                Console.WriteLine("1.Perform Operations \n2.Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice != 2)
                    Book.AddPerson();
            }
            Book.ListPeople();
            Console.WriteLine("Program Ends: Address Book: Press Enter");
            Console.ReadLine();

        }
    }
}
