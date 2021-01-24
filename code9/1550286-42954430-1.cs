    var results = (from user in context.Users
                   from phone in user.Phones
                   orderBy user.Id
                   group phone.Number by user into g
                   select new {
                       g.Key.Id,
                       g.Key.Name,
                       Phones = g.ToList()})
                  .AsEnumerable()
                  .Select(x => new User{
                       Id = x.Id,
                       Name = x.Name,
                       Phones = string.Join(",", x.Phones)})
                  .ToList();
                       
