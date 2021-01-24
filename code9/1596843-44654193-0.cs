    var nonEmptyLines = File.ReadAllLines(FileName)
                            .Where(x => !x.Split(',')
                                         .Take(2)
                                         .Any(cell => string.IsNullOrWhiteSpace(cell))
                             // use `All` if you want to ignore only if both columns are empty.  
                             ).ToList();
