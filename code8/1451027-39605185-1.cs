            var regex = new Regex(@"\[([a-zA-Z0-9\,]+)\]");
            var stringOne = "[952,M] [782,M] [782] {2[373,M]} [1470] [352] [235] [234] {3[610]}{3[380]} [128] [127]";
            var matches = regex.Matches(stringOne);
            var listStrings = new List<string>();
            
            foreach (Match match in matches)
            {
                var repetitor = 1;
                string value = null;
                if (match.Groups[1].Value == string.Empty)
                {
                    repetitor = int.Parse(match.Groups[4].Value);
                    value = match.Groups[5].Value;
                }
                else
                {
                    value = match.Groups[2].Value;
                }
 
                var values = value.Split(',');
                for (var i = 0; i < repetitor; i++)
                {
                    listStrings.AddRange(values);
                }
            }
