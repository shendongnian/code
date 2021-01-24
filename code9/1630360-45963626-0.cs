    var qble = list.AsQueryable();
    
    var query1 = new Predicate<testClass>(x => x.name == "name" && x.id == 1);
    var query2 = new Predicate<testClass>(x => x.age == 30);
    
    var predQuery = qble.AsExpandable().Where(x => query1(x) || query2(x));
