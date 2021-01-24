    return db.States
                .Where(predicate)
                .Select(states => new
                {
                    Id = states.Id,
                    Country_Id = states.Country_Id,
                    Name = states.Name,
                    PhoneCode = states.PhoneCode
                }).ToList()
