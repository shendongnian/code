    public void GetWarningsGroup(IEnumerable<Warning> warnings)
            {
                var result = warnings
                    //Only Active warnings
                    .Where(w => w.Active)
                    //Grouped By year - Selecting the WarningYearCounter
                    .GroupBy(w => w.StartDate.Year, w => w.WarningYearCounter)
                    //Force Linq-To-SQL execution
                    .ToList()
                    //Finally concatenate the WarningYearCounter into the result
                    .Select(g => new Tuple<int, string>(g.Key, string.Join(",", g)));
            }
