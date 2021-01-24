    List<Destination> destinations = new List<Destination>();
    MySqlDataReader reader = DBHandler.Query("SELECT * FROM destinations", dataLoaderForDestination);
    Console.WriteLine("Loaded " + destinations.Count + " destinations");
    private void dataLoaderForDestination(MySqlDataReader reader)
    {
        Destination dest = new Destination();
        dest.Address = reader.GetString(0);
        dest.Nation = reader.GetInt32(1);
        ...
        destinations.Add(dest);
    }
