    var db = new MyContext();
   
    var a = db.LoadList(); // or whatever
    var b = new List<IQueryable<Entities>>(db.LoadListOfLists()/*or whatever*/);
    b.Any(x => x.Count.Equals(a.Count) & x.All(y => a.Any(z => z.Id == y.Id)));
