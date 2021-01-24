    var result = new[] {true, false}.ToDictionary(k => k,
                v =>
                    s.Results.Where(w => w.List.Any(x => x.AllowedAccess == v))
                        .Select(c => new GroupedObject {Name = c.Name, List = c.List.Where(l => l.AllowedAccess == v)}));
     var allowedResults = result[true];
     var restrictedResults = result[false];
