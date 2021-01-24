    var rx = new Regex(@"<a href="".*?"">(?<date>\d{8})/</a>\s+\d{2}-.{3}-\d{4}\s(?<hh>\d{2}):(?<mm>\d{2})");
    var oldest = rx.Matches(testInput).Cast<System.Text.RegularExpressions.Match>().
                Where(match => match.Success).
                Select(g =>
                {
                    decimal result;
                    decimal.TryParse(g.Groups["date"].Value + g.Groups["hh"].Value + g.Groups["mm"].Value, out result);
                    return result;
                }
            ).Except(new[] { default(decimal) }).OrderBy(dt => dt).FirstOrDefault();
                  
                  
