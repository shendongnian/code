    public static void ParseSqlScript(string sqlScriptPath)
        {
            using (var reader = new StreamReader(sqlScriptPath))
            {
                var sqlScript = reader.ReadToEnd();
                var pattern = @"INSERT INTO \[dbo\].\[State\] \(\[Id\], \[Code\], \[Name\]\) VALUES (\(.*?\))";
                var regex = new Regex(pattern);
                var matches = regex.Matches(sqlScript);
                foreach (Match match in matches)
                {
                    var values = match.Groups[1].Value.Split(new [] { '(', ',',' ',')' }, StringSplitOptions.RemoveEmptyEntries);
                    var id = int.Parse(values[0]);
                    var code = values[1].Substring(2, values[1].Length - 3);
                    var name = values[2].Substring(2, values[2].Length - 3);
                    foreach (var value in values)
                    {
                        Console.WriteLine($"{id}; {code}; {name}");
                        var state = new State() { Id = id, Code = code, Name = name };
                    }
                }
            }
        }
