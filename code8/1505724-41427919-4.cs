    //Save array
    public void Save()
    {
        StreamWriter file = File.CreateText(Settings.databasePath +  "customer.json");
        using (JsonTextWriter writer = new JsonTextWriter(file))
        {
            //Save JArray of customers
            customers.WriteTo(writer);
        }
    }
