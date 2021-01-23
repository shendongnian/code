    public AddressALL[] getAddesses(int NumberOfRecords, string AddressInput)
    {
        try
        {
            using (GISAddressEntities database = new GISAddressEntities())
            {
                return database.prcGetCOBAddress(NumberOfRecords, AddressInput).ToArray();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new AddressALL[0];
        }
    }
