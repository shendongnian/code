    public void Save(DocumentBase document)
    {
        var actions = new Dictionary<Type, Action<DocumentBase>>
                          {
                              { typeof(DocumentA), d => this.RepositoryFactory.Get<DocumentA>().Update(d) },
                              { typeof(DocumentB), d => this.RepositoryFactory.Get<DocumentB>().Update(d) },
                          };
        actions[typeof(DocumentBase)](document);
    }
