    static void Main(string[] args) {
        Console.WriteLine("Do you want to read the bookings?");
        string response = Console.ReadLine();
        if (response == "1")
            ReadBookings();
        else {
            Console.WriteLine("Do you want to create a booking?");
            response = Console.ReadLine();
            if (response == "1")
                CreateBooking();
        }
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
    
    static void ReadBookings() {
        DateTime startDate, endDate;
        Console.WriteLine("Input start date in the format yyyy-mm-dd");
        startDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Input end date in the format yyyy-mm-dd");
        endDate = DateTime.Parse(Console.ReadLine());
        DbBookings bookings = new DbBookings(bookingStartDate, bookingEndDate);
        foreach (DbBooking booking in bookings.Bookings)
            Console.WriteLine($"booking start date: {booking.startDate}\nbooking end date: {booking.endDate}\nbooking room No: {booking.roomNo}\nbooking guest: {booking.guestName}\nbooking guest phone No: {booking.guestPhone}\nbooking cost: {booking.cost});
    }
     
    static void CreateBooking() {
        DateTime startDate, endDate;
        string name, phone;
        int room;
        double cost;
        Console.WriteLine("Bed and breakfast create new booking");
        Console.WriteLine("Input start date in the format yyyy-mm-dd");
        startDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Input end date in the format yyyy-mm-dd");
        endDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("What room?");
        room = int.Parse(Console.ReadLine());
        Console.WriteLine("Customer Name");
        name = Console.ReadLine();
        Console.WriteLine("Customer phone number");
        phone = Console.ReadLine();
        cost = (endDate.ToOADate() - startDate.ToOADate()) * 29;
        DbBooking newBooking = new DbBooking(startDate, endDate, room, name, phone, cost);
    }
