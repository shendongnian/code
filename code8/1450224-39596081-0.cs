    IEnumerable<EntityCollection> GetAll(OrganizationServiceProxy proxy, IEnumerable<QueryBase> queries)
    {
      return queries.AsParallel().WithDegreeOfParallelism(10)
          .Select(query => proxy.RetrieveMultiple(query));
    }
