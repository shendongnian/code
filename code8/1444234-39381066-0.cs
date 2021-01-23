    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "\"Legend of Tarzan\" \"Lord of Dance\"";
                string pattern = "\"(?'phase'[^\"]+)\"";
                MatchCollection matches = Regex.Matches(input, pattern);
                List<string> wheres = new List<string>();
                foreach (Match match in matches)
                {
                    wheres.Add(string.Format("title % '{0}'", match.Groups["phase"].Value));
                }
                string whereClause = string.Format("WHERE {0}", string.Join(" OR ", wheres));
                string SQL = string.Format(
                    " SELECT movie_id, ts_headline, title, ts_rank, rank" +
                    " FROM movies" +
                    " {0}" +
                    " ORDER BY rank DESC",
                    whereClause);
            }
        }
    }
