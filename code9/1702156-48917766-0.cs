    public static void PrintTicketsByDesk(DateTime from, DateTime to)
    {
        Console.WriteLine(string.Join(", ", desks.SelectMany(kvp => 
            kvp.Value.Where(ticket => BoughtBetween(ticket, from, to)))));
    }
