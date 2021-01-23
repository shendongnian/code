    public List<TProp> MyQueryFunction<TProp>(Expression<Func<TDomain, TProp> selector)
    {
          var query = ....; // your query here without .ToList() at the end
    
          if(query != null)
             query.Select(selector)
    
          return query.ToList();
    }
