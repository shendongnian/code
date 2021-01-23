    var personDTO = context.Person
                   .Where(p => p.Id == 1)
                   .Select(p => new {
                      person = p,
                      homeAddress = p.PersonXAddresses
                                     .FirstOrDefault(px => px.Address.AddressTypeID == 1)
                                     .Address })
                   .Select(pd > new PersonDto {
                       Id = person.Id
                       Name = person.Name,
                       ...
                       HomeAddress = homeAddress
                   }).ToList();
