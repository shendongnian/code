    public List<string> getAddressSearchSimple(string addressInput)
    {
        List<string> address = new List<string>();
        try
        {
            using (GISAddressEntities database = new GISAddressEntities())
            {
                var addressData = (from table in database.view_COBADDRESS
                                   where table.ADD_FULL.Contains(addressInput)
                                   select new { table.ADD_FULL, table.POSTALCITY, table.STATE, table.ZIP5 });
                address = addressData.Select(x => string.Format("{0} {1} {2} {3}", x.ADD_FULL, x.POSTALCITY, x.STATE, x.ZIP5))
                    .ToList();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return address;
    }
