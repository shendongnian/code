     public IEnumerable<DettagliModel> ConvertTo(IQueryable<Dettagli> entities)
    {
       
        return entities.ProjectTo<DettagliModel>().ToList();
    }
