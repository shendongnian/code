    public async Task<YourEntity> GetYourEntity()
    {
      using (var myContext = new DbContext())
      {
        var returnObj = (from rp in myContext.Services1
                         join op in myContext.Services2 on rp .Id equals op.ServiceId into g
                         join ep in myContext.Services3 on rp .Id equals ep.ServiceId
                         from n in g.DefaultIfEmpty()
                         where rp.Name == code
                         select rp).FirstOrDefaultAsync();
    
        //return returnObj; // returns Task, wrong!
        return await returnObj; // returns result, right!
      }
    }
