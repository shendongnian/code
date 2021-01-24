    public List<Case> GetAllCases()
        {
            var result = (from c in _Context.Cases
                         join s in _Context.CaseStatus on c.CaseStatusId 
                         equals s.CaseStatusId
                         select new Case () { CaseId = c.CaseId, CaseStatusId = c.CaseStatusId  }).ToList();
    
            return result;
    }
