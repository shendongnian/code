     List<CustomData> list = new List<CustomData>();
            list.Add(new CustomData() { full_name = "test", location = "test", week1 = 0, week2 = 1, week3 = 2 });
            list.Add(new CustomData() { full_name = "test2", location = "test2", week1 = 0, week2 = 12, week3 = 22 });
            List<Category> categories = new List<Category>();
            categories.Add(new Category { Color = 0, Name = "testName", Record_ID = 0 });
            categories.Add(new Category { Color = 1, Name = "testName1", Record_ID = 1 });
            categories.Add(new Category { Color = 2, Name = "testName2", Record_ID = 2 });
            categories.Add(new Category { Color = 3, Name = "testName3", Record_ID = 12 });
            categories.Add(new Category { Color = 4, Name = "testName4", Record_ID = 22 });
            List<WeekView> results = new List<WeekView>();
            results.AddRange(list.Select(x=> 
                  new WeekView() { full_name = x.full_name, 
                                   location = x.location, 
                                   week1 = categories.Where(c=>c.Record_ID == x.week1).FirstOrDefault(), 
                                   week2 = categories.Where(c => c.Record_ID == x.week2).FirstOrDefault(), 
                                   week3 = categories.Where(c => c.Record_ID == x.week3).FirstOrDefault() 
                                  }));
