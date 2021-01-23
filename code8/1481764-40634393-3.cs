           // example data
           Dictionary<Restaurant, string> restaurants = new Dictionary<Restaurant, string>();
            restaurants.Add(new Restaurant("r1") ,"A");
            restaurants.Add(new Restaurant("r2") ,"B");
            restaurants.Add(new Restaurant("r3") ,"A");
            restaurants.Add(new Restaurant("r4") ,"B");
            restaurants.Add(new Restaurant("r5") ,"A");
            restaurants.Add(new Restaurant("r6") ,"B");
            restaurants.Add(new Restaurant("r7") ,"A");
            restaurants.Add(new Restaurant("r8") ,"B");
            // 3 Random restaurants from group "A"
            List<Restaurant> randomRestaurants = restaurants.GroupBy(a=>a.Value).FirstOrDefault(a=>a.Key=="A")
                .RandomValues(3).Select(x=>x.Key).ToList();
            randomRestaurants.Clear();
            // 1 random restaurant per group
             List<Restaurant> randomRestaurants2 = restaurants
                 .GroupBy(a => a.Value)
                 .Select(a => a.RandomValues(1).FirstOrDefault().Key)
                 .ToList();
             // or, with SelectMany, 2 random restaurants per type:
                  List<Restaurant> randomRestaurants3 = restaurants.GroupBy(a => a.Value)
                 .SelectMany(a => a.RandomValues(2))
                 .Select(d=>d.Key).ToList();
