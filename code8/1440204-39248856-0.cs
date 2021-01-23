    public class YourClass
    {
        public int Position { get; set; }
        public int DesignPosition { get; set; }
    }
    var PositionList = pairList.GroupBy(o => o.pair.Item1.Date)
                               .Select(o => AddTwoList.GroupBy(p => p.Key)
                                                      .Select(p => new YourClass {                    
                                                          DesignPosition = p.Sum(q => q.DesignPosition),
                                                          Position = 0                   
                                                       }).ToList())
                               .ToList();
    for (int i = 0; i < PositionList.Count - 1; i++)
    {
        for (int j = 0; j < PositionList[i].Count; j++)
        {
            if (Math.Abs(PositionList[i][j].DesignPosition - PositionList[i][j].Position) < T)
            {
                PositionList[i][j].DesignPosition = PositionList[i][j].Position;
                PositionList[i + 1][j].Position = PositionList[i][j].DesignPosition;
            }
        }
    }
