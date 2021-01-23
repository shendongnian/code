    var source = new[] {
       new { FirstName = "Foo", SurName = "Bar", Password = "secret" },
    };
    
    var membersToInclude =
       source
          .First()
          .GetType()
          .GetProperties()
          .Where(x => x.Name != "Password")
          .Select(x =>
              {
                var value = x.GetValue(source.First());
                return new {x.Name,  value};
              })
          .ToArray();
    
    foreach (var m in membersToInclude)
    {
       m.Dump();
    }
