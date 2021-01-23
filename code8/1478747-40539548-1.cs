    static void Main(string[] args)
    {
        var seating = new AirplaneSeating();
        // Use PrintToConsole to print seating to screen.
        seating.PrintToConsole();
        // You can find a specific seat by its position.
        var seat1 = seating["1A"]; // Gives me seat 1A
        var seat2 = seating[1, 1]; // Also gives me seat 1A
        // Then you can put a passenger on this seat if you want.
        seat2.Passenger = "Jhon";
        // When you set a passenger name to the seat, its status will change.
        Console.WriteLine("Seat 1A status is {0}.", seat1.Status); // Occupied
        // You can find a specific seat by passenger name.
        // This line of code gives me seat 1A, wich is now Jhon's seat.
        var occupiedSeat1 = seating.FindSeatOccupiedBy("Jhon");
        // You can find by typing a part of the passenger name, 
        // and you don't need to worry about capitalization
        var occupiedSeat2 = seating.FindSeatOccupiedBy("JHO");
        // You can print seat information on console.
        Console.WriteLine("Seat {0} is occupied by {1}.", 
            occupiedSeat2.Position.ToString(), occupiedSeat2.Passenger);
        Console.ReadLine();
    }
