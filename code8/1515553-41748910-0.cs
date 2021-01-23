        {
            List<Instituition> Instituitions = new List<Instituition>() { 
            new Instituition { Name = "Name1", Alias = "",Area="" },
            new Instituition { Name = "Name1", Alias = "Alias1",Area="" },
            new Instituition    { Name = "name2", Alias = "Audi" ,Area="444"},
             new Instituition { Name = "Name1", Alias = "",Area="Garden" }};
          
            var results = Instituitions.GroupBy(i =>  i.Name,
                               i => i.Alias,
                               (key, g) => new
                               {
                                   Name = key,
                                   Alias = g.Where(a =>a != "").FirstOrDefault(),
                                   Area = Instituitions.Where(a=>a.Name == key && a.Area != "").Select(a=>a.Area).FirstOrDefault()
                               }                             
                              
                              );
        
        }
        class Instituition
        {
            internal string Name;
            internal string Alias;
            internal string Area;
        }
