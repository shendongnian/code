    List<OnlineContactChangeTableModel> ret = new List<OnlineContactChangeTableModel>();
    List<int> lIds = new List<int>();
    ret = db.Address.AsNoTracking().Where(a => a.IsProcessed == false && 
                                          a.IsDeleted == false).ToList()
             .Select(aa => new OnlineContactChangeTableModel(aa)).ToList();
    lIds.AddRange(ret.Select(s => s.Id).ToList();
    ret.AddRange(db.Email.AsNoTracking().Where(a => !lIds.Any(rr => rr == a.Id) &&  
                                          a.IsProcessed == false && 
                                          a.IsDeleted == false).ToList()
             .Select(aa => new OnlineContactChangeTableModel(aa)).ToList());
