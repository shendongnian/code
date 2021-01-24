    public async Task<IEnumerable<TEntity>> GetByExpression(Expression<Func<TEntity, bool>> expression)
            {
                IEnumerable<TEntity> IEnumerable;
                List<TEntity> List = new List<TEntity>();
    
                try
                {
                    IDocumentQuery<TEntity> Queryable = client.CreateDocumentQuery<TEntity>(documentCollectionUri)
                                                     .Where(expression)
                                                     .AsDocumentQuery();
    
                    while (Queryable.HasMoreResults)
                    {
                        foreach (TEntity t in await Queryable.ExecuteNextAsync<TEntity>())
                        {
                            List.Add(t);
                        }
                    }
                   
                }
                catch (DocumentClientException ex)
                {
                    throw ex;
                }
                IEnumerable = List;
                return IEnumerable;
            }
