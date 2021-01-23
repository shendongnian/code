    public IEnumerable<DettagliModel> ConvertTo(IQueryable<Dettagli> entities)
    {
       
        return entities.ProjectTo<DettagliModel>().ToList();
    }
    public IEnumerable<DettagliModel> GetByIdDocs(int id)
    {
        using (var dbCtx = new USDevEntities())
        {
            return ConvertTo(dbCtx.Dettaglis.Where(x => x.IDDoc == id));
            
        }
    }
