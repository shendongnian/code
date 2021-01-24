    var rx = new System.Text.RegularExpressions.Regex(@"<a href="".*?"">.*?</a>\s*?(?<datetime>\d{2}-.{3}-\d{4} \d{2}:\d{2})");
    var theFirstDateTime = rx.Matches(testInput).Cast<System.Text.RegularExpressions.Match>().Where(match => match.Success).Select(
                g =>
            {
                DateTime result;
                DateTime.TryParseExact(g.Groups["datetime"].Value,
                    "dd-MMM-yyyy hh:mm", null, System.Globalization.DateTimeStyles.None, out result);
                return result;
            }
            ).Except(new[] { default(DateTime) }).OrderBy(dt => dt).FirstOrDefault();
                  
                  
