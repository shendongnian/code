    public List<IdTextModel> GetList(
        Expression<Func<Entity,string>> selectorId
    ,   Expression<Func<Entity,string>> selectorName
    ) {
        return data
           .Select(selectorId)
           .Zip(
               data.Select(selectorName)
           ,   (id, name) => new IdTextModel { Id = id, Name = name }
           ).ToList();
    }
