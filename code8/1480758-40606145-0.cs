    int counter = 0;
    foreach (var post in _sdb.Posts.Include("xxx"))
    {
        post.Floor = CorrectFloor(post);
        post.RealAge = AgeCalculator(post);
        post.Area = TerasCheck(post);
    
        _sdb.Entry(post).State = System.Data.Entity.EntityState.Modified;
        counter++;
    }
    
    _sdb.SaveChanges();
    Console.WriteLine("SaveChanges worked, counter : " + counter);
    
