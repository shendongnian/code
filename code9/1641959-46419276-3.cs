        static void Main()
        {
            TicketNumber ticketNumber = new TicketNumber();
            ticketNumber.AlphaPrefix = "ZZZ";
            ticketNumber.NumericPrefix = "9999";
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(ticketNumber);
                ticketNumber.Increment();
            }
            Console.Read();
        }
