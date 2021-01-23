    public IEnumerable<DealerInfo> GetMyPage(Expression<Func<Principal, bool>> filter, int pageNumber, int pageSize, out int totalCount)
    {
        List<DealerInfo> dealers;
    
        using (MyContext pdx = new MyContext())
        {
            totalCount = pdx.Principals.Count(filter);
            // More LINQ stuff here, but UGH the performance...
        }
    }
