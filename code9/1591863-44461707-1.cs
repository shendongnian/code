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
        foreach (DbBooking booking in bookings.Bookings)
        {
            Console.WriteLine("booking start date = " + booking.startDate);
            Console.WriteLine("booking end date = " + booking.endDate);
            Console.WriteLine("booking room No = " + booking.roomNo);
            Console.WriteLine("booking guest = " + booking.guestName);
            Console.WriteLine("booking guest phone No = " + booking.guestPhone);
            Console.WriteLine("booking cost = " + booking.cost);
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
