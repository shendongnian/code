       string name, price;
        foreach (var item in myListOfVechicles)
        {
            name = item is ElectricalDriven ? 
                           (item as ElectricalDriven).Name : 
                           (item as GasolinDriven).Name;
            price = item is ElectricalDriven ? 
                            (item as ElectricalDriven).Price :
                            (item as GasolinDriven).Price;
    
            Console.WriteLine($"Name: {name} - Price: {price}");
        }
