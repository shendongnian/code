    public List<Destination> GetOversizeRegulations(List<string> states)
    {
            
            var tmpDictionary = (from i in _db.States
                                 where states.Contains(i.Name)
                                 select new
                                          {
                                            StateID = i.Id,
                                            StateName = i.Name,
                                            StateShortName = i.ShartName
                                          }
                                  ).ToDictionary(k => k.StateName, k => k);
            var result = states.Select(m => tmpDictionary[m]).ToList();
     }
