    var query = Vehiclelist;
    if (column == "Trucks")
    {
        query = query.Where(q => q.Trucks=="Y");
    }
    else if (column == "Cars")
    {
        query = query.Where(q => q.Cars=="Y");
    }
    else if (column == "Utility")
    {
        query = query.Where(q => q.Utility=="Y");
    }
