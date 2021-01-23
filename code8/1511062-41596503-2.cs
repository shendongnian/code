    FooList.ForEach((x) =>
                {
                    //Define a new expando
                    dynamic NewClass = new ExpandoObject();
                    NewClass.Id = x.Id;
                    NewClass.Name = x.Name;
                    //Get the relating Bar Record
                    BarList.Where(b=> b.FooId == x.Id).ToList().ForEach((b) =>
                    {
                        NewClass[b.Title] = b.Count;
                    });
                    //This bit Depends on how you want the Json
                    using (TextWriter writer = System.IO.File.CreateText("YourFilepat/Here"))
                    {
                        var serializer = new JsonSerializer();
                        serializer.Serialize(writer, NewClass);
                    }
    
                });
