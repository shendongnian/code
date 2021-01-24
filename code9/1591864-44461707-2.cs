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
    
    void ReadBookings() {
        Console.WriteLine("Input start date in the format yyyy-mm-dd");
        DateTime bookingStartDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Input end date in the format yyyy-mm-dd");
        DateTime bookingEndDate = DateTime.Parse(Console.ReadLine());
        DbBookings bookings = new DbBookings(bookingStartDate, bookingEndDate);
        string output = "booking start date: {0}\nbooking end date: {1}\nbooking room No: {2}\nbooking guest: {3}\nbooking guest phone No: {4}\nbooking cost: {5}";
        foreach (DbBooking booking in bookings.Bookings) {
            Console.WriteLine(string.Format(output, booking.startDate, booking.endDate, booking.roomNo, booking.guestName, booking.guestPhone, booking.cost));
        }
    }
     
    void CreateBooking() {
        Console.WriteLine("Bed and breakfast create new booking");
        Console.WriteLine("Input start date in the format yyyy-mm-dd");
        DateTime startDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Input end date in the format yyyy-mm-dd");
        DateTime endDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("What room?");
        int room = int.Parse(Console.ReadLine());
        Console.WriteLine("Customer Name");
        string name = Console.ReadLine();
        Console.WriteLine("Customer phone number");
        string phone = Console.ReadLine();
        double cost = (endDate.ToOADate() - startDate.ToOADate()) * 29;
        DbBooking newBooking = new DbBooking(
            startDate,
            startDate,
            room,
            name,
            phone,
            cost
            );
        Console.ReadLine();
    }
