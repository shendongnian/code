    var Sessions = (from a in db.Appointments
                    join c in db.Clients
                    on a.clientid equals c.id into SessionList
                    from c in SessionList.DefaultIfEmpty()
                    .Select(y => new SessionViewModel()
                    {
                        id = y.id,
                        sessionnotes = y.sessionnotes,
                        firstname = y.firstname,
                        date = y.date,
                    }).ToList();
