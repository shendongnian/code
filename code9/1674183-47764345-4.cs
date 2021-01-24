    static void Main(string[] args)
    {
        string input = "";
        while(input != "exit" || input != "Exit")
        {
            Console.Write("Input: ");
            input = Console.ReadLine();
            string inputDate = input;
            //try to parse it
            try
            {
                DateTime date = DateTime.Parse(inputDate);
                Console.WriteLine(date+"\n");
            }
            catch
            {
                //Exceptions. String not valid because ambiguity
                Console.WriteLine("Ambiguous.\n");
                //In here can also perform other logic, of course
            }
            
        }
        
    }
