    public static class MyExtensions
    {
      public IQueryable<THeader> ByClientId(this IQuerable<THeader> conn, int ClientID)
      {
        return conn
          .Include(h=>h.Reports)
          .Where(h=>h.ClientID==ClientID);
      }
      public TReportHeaderModel ToDto(this THeader t)
      {
        return new TReportHeaderModel
        {
          ID=t.ID,
          ClientID=t.ClientID,
          THeaderTitle=t.THeaderTitle,
          RowNumber=t.RowNumber,
          Reports=t.Reports.ToDto()
        };
      }
      public TReportModel ToDto(this TReport r)
      {
        return new TReportModel
        {
          ID=r.ID,
          TReportName=r.TReportName,
          URL=r.URL,
          RowNumber=r.RowNumber
        };
      }
      public IEnumerable<TReportHeaderModel> ToDto(this IEnumerable<THeader> h)
      {
        return h.Select(x=>x.ToDto());
      }
      public IEnumerable<TReportModel> ToDto(this IEnumerable<TReport> r)
      {
        return r.Select(x=>x.ToDto());
      }
    }
