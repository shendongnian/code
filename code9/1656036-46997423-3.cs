    public interface IDataAccess<TEntity>
    {
        // no need for collectionName parameter
        // because each concrete entity handler knows its collection name
        Task InsertAsync(TEntity entity); 
        // .... other CRUD methods
    }
