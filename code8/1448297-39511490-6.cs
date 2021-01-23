    db.Persons.Select(p => new PresonDto
                               {
                                   Id = p.Id,
                                   FirstName = p.firstname,
                                   LastName = p.lastname,
                                   FullName = p.firstname ?? "" + " " + p.lastname ?? ""
                               });
