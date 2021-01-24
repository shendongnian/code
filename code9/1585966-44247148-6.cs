    static ConsoleColor[] ticketPriorities = { //and give descriptive name to list
          ConsoleColor.Green, 
          ConsoleColor.Yellow,
          ConsoleColor.Red,
          ConsoleColor.Magenta
        }; //Ticket Colors.
    var patientsQueue = patients
         .OrderByDescending(p => ticketPriorities.IndexOf(p.Priority))
         .ToList();
