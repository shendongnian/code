    public async Task<GenericBox> GetBox(Box box)
    {
        try
        {
            //Do a lot of stuff with the database
            //'await' database calls here
            return genericBox;
        }
        catch (Exception e)
        {
            return null;
        }        
    }
