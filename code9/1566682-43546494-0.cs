    var query = from item in list
    	group item by item.Theme into group
    	select new { Question = group.Key, Count = group.Count()};
    foreach(var item in query){
    	Console.WriteLine("{0} {1}", item.Question, item.Count);
    }
        Dictionary<string, int> themes = new Dictionary<string, int>();
    
