    public Dictionary<DateTime, int> GetDataWeekly(IQueryable<Entity> entities, DateTime from, DateTime to)
            {
                var graphData = new Dictionary<DateTime, int>();
    
                var weekValues = entities.GroupBy(o => new
                {
                    Year = SqlFunctions.DatePart("yyyy", o.DateCreated),
                    Week = SqlFunctions.DatePart("ww", o.DateCreated)
                }).ToDictionary(o=> o.Key, o=>o.Count());
    
                var currentWeekDateTime = from;
    
                while (currentWeekDateTime < to)
                {
                    var total = 0;
    
                    var currentWeekNumber = GetWeekOfYear(currentWeekDateTime);
    
                    var generatedKey = new
                    {
                        Year = (int?)currentWeekDateTime.Year,
                        Week = (int?)currentWeekNumber
                    };
    
    
                    if (weekValues.ContainsKey(generatedKey))
                    {
                        total = weekValues[generatedKey];
                    }
    
                    graphData.Add(currentWeekDateTime, total);
    
                    currentWeekDateTime = currentWeekDateTime.AddDays(7);
                }
    
                return graphData;
    
            }
