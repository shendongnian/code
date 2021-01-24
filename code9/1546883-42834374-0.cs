    Users.Where(w => w.Region == 1321)
         .Select(s => s.Id)
         .Join(Added, a => a, s => s.UserId , (a, s)=> new
         {
             UserId = a.UserId,
             PersonId = s.PersonId,
             SevenDays = s.AddDate >= firstdate.AddDays(-7),
             ThirtyDays = s.AddDate >= firstdate.AddDays(-30),
         })
         .Join(Status, s => s.PersonId, y => y.PersonId, (s, y)=> new
         {
             PersonId = s.PersonId,
             Bum = y.Bum,
             Jobless = y.Jobless,
             PreviouslyConvicted = y.PreviouslyConvicted
         })
         .Join(Photos, p => p.PersonId, y => y.PersonId, (p, y) => new
         {
             PersonId = p.PersonId,
             WithPhotos= y.Photo
         })
   
     
