    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter name and press key Enter:");
            string inputString = Console.ReadLine();
            try
            {
                Man p = new Man(inputString);
                Console.WriteLine($"Entered name - {p.Name} - is valid.");
            }
            catch (InvalidInputCustomException ex)
            {
                Console.WriteLine($"Invalid input type - {ex.InputExceptionType}. Please enter valid name.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandled exception " + ex.Message);
            }
            Console.WriteLine("Press any key to finish the program.");
            Console.ReadLine();
        }
    }
