    public TEntity MapFrom(T dto)
    {
        return new TEntity
        {
            Name = dto.Name,
            Description = dto.Descrption,
            // etc..
        }
    }
