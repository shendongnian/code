    void Submit()
    {
        DateTime? pickupdate = PickupDate.Date.DateTime;
        DateTime? retdate    = ReturnDate.Date.DateTime;
        // This is useless, this instance is not used anywhere (Frame.Navigate creates its own new instance)
        // Reservation res = new Reservation(pickupdate.Value.ToString("dd-MM-yyyy"), retdate.Value.ToString("dd-MM-yyyy"));
        
        string[] parameters = { pickupdate.Value.ToString("dd-MM-yyyy"), retdate.Value.ToString("dd-MM-yyyy") };
        Frame.Navigate(typeof(Reservation), parameters);
    }
