    public override IServiceResult<IList<Rolle>> LoadAllData()
    {
        using (var db = this.DomainContextFactory.Create())
        {
            Task<List<Rolle>> rollen = db.Roles
                .ToListAsync<Rolle>();
            return new ServiceResult<IList<Rolle>>(rollen.Result, rollen.Result.Count);
     
        }
    }
