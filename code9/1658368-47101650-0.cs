    var users = (from p in Context.Users
                 where p.Username == username
                 select p).ToList().ForEach(x =>
                 {
                     x.Score += score;
                     x.Bonus += bonus;
                 });
    Context.SaveChanges();
