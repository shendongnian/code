            string pattern = "[0-9]";
            string input = "sadsad 2 fsdg 4 njnjk 5 njnsdf 9 jytjtj";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection result = rgx.Matches(input);
            var resultList = new List<Int32>(); 
            foreach (Match match in result)
            {
                resultList.Add(Int32.Parse(match.Value));
            }
