    public static IEntityCollection2 GetEntityCollection<T>() where T : EntityBase2
    {
        using (DataAccessAdapter adapter = new DataAccessAdapter())
        {
            IEntityCollection2 collection = new EntityCollection<T> ();
            try
            {
                adapter.FetchEntityCollection(collection, null);
            }
            catch
            {
                //Log Exception
            }
    
            return collection;
        }
    }
