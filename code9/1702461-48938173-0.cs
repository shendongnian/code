    var personWithLocation = context.Persons
            .SelectMany(p => context.ViewPersonLastLocations
                                    .Where(vp => vp.person_id == p.id)
                                    .DefaultIfEmpty(),
                             (p, vp) => new PersonViewModel  // create a viewmodel for results or anonymous
                             {
                                 Id = p.id,
                                 Name = p.name,
                                 LastName = p.lastname,
                                 LocationName = vp.location_name
                             }
                         ).ToList();
