       var Sessions = (from a in db.Appointments
                                 join c in db.Clients
                                 on a.clientid equals c.id into SessionList
                                 from c in SessionList.DefaultIfEmpty()
                                 select new SessionViewModel()
                                 {
    
                                    id = a.id,
                                     sessionnotes = a.sessionnotes,
                                     firstname = c.firstname,
                                     date = a.date,
    
                                 }).ToList()
                       .Select(x => new SessionViewModel()
                        {
                             id = x.id,
                             sessionnotes = x.sessionnotes,
                             firstname = x.firstname,
                             date = x.date,
                        });
    
