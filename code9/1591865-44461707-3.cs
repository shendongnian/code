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
        string output = "booking start date: {0}\nbooking end date: {1}\nbooking room No: {2}\nbooking guest: {3}\nbooking guest phone No: {4}\nbooking cost: {5}";
        Console.WriteLine("Input start date in the format yyyy-mm-dd");
        startDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Input end date in the format yyyy-mm-dd");
        endDate = DateTime.Parse(Console.ReadLine());
        DbBookings bookings = new DbBookings(bookingStartDate, bookingEndDate);
        foreach (DbBooking booking in bookings.Bookings) {
            Console.WriteLine(string.Format(output, booking.startDate, booking.endDate, booking.roomNo, booking.guestName, booking.guestPhone, booking.cost));
        }
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
