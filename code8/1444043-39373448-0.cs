        public IList<RelationshipExperience> sp_GetRelationshipExperience(int programId, bool AllPrograms)
        {
                var output = _CatContext.sp_GetRelationshipExperience(programId)
    .Where(l => l.InProgramChain == 1)
    .GroupBy(l => l.UWYear)
    .Select(r => new RelationshipExperience
    {
        UWYear = r.Key,
        Earned = r.Sum(c => c.Earned),
        IncLoss = r.Sum(c => c.IncLoss),
        Expenses = r.Sum(c => c.Expenses),
        Balance = r.Sum(c => c.Balance),
    }).ToList();
                return output;
            }
