    var result = data.GroupBy(key => key.Role)
                     .Select(g => new {
                         Role = g.Key,
                         Documents = g.Select(i => i.DocumentType)
                     });
 
