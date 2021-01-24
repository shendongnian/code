            Class.Column[] Columns = this.ColumnNames
                .Select(x=> Regex.Match(x, reg))
                .Select(z =>
                new Class.Column()
                {
                    Param1 = z.Groups[1].ToString(),
                    Param2 = z.Groups[2].ToString()
                }).ToArray();
