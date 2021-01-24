    public static TEntity CloneEntity<TEntity>(this BaseEntity input) where TEntity 
        : BaseEntity
    {
        if (input == null) return null;
        var serialized = JsonConvert.SerializeObject(input);
        return (TEntity)JsonConvert.DeserializeObject(serialized, input.GetType());
    }
