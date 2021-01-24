    public async Task<IEnumerable<T>> QueryAsync
      (Expression<Func<T, bool>> predicate, string orderByProperty)
    {
       client.CreateDocumentQuery<T>(myCollectionUri)
           .Where(predicate)
           .OrderBy(orderByProperty)   // uses dynamic LINQ
           .AsDocumentQuery();
       /* rest of the code... */
    }
