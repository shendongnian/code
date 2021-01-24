    TReportEntitiesConnection conn = new TReportEntitiesConnection();
    
    public IQueryable<THeader> GetHeadersByClient(int ClientID)
    {
      return conn.THeaders
        .Include(h=>h.Reports)
        .Where(h=>h.ClientID==ClientID);
    }
