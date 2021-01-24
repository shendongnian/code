    public static void PrintTicketsByDesk(DateTime from, DateTime to)
    {
        Console.WriteLine(string.Join(", ", desks.Values.SelectMany(value => 
            value.Where(ticket => BoughtBetween(ticket, from, to)))));
    }
