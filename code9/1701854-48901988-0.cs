    public List<Group<int, BillPeriodLine>> GetLinesGroupedByPeriod()
    {
        var linesGrouped = _lineRepository.AllIncluding(p => p.BillPeriod)
                                          .GroupBy(pl => pl.BillPeriodId)
                                          .Select(g => new Group<int, BillPeriodLine>
                                          {
                                              Key = g.Key,
                                              Values = g
                                          });
        return linesGrouped.ToList();
    }
