       using(var context = new YourContext())
       {
            List<YourEntity> entities = new List<YourEntity>();
            File.ReadAllLines("PathToFile")
                .ToList()
                .ForEach(s =>
                {
                   string[] split = s.Split(',');
                   someList.Add(new YourEntity(split[0], split[1])); // Or set properties if not using a constructor.
                });
            
            context.YourTable.AddRange(entities);
            context.SaveChanges();
       }
