    public void Save(DocumentBase document)
    {
        var actions = new Dictionary<Type, Action<DocumentBase>>
                          {
                              { typeof(DocumentA), d => this.RepositoryFactory.Get<DocumentA>().Update((DocumentA)d) },
                              { typeof(DocumentB), d => this.RepositoryFactory.Get<DocumentB>().Update((DocumentB)d) },
                          };
        actions[typeof(DocumentBase)](document);
    }
