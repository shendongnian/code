    // by doing groupby and select you choose only one address of the type,
    // if a person has many.
    // If you can be sure that each person has only one address of each type
    // then you can simplify these queries a little bit.
    IEnumerable<PersonAddresses> homeAddresses = from address in addresses
                                                 where address.AddressType == "HomeAddress"
                                                 group address by address.id into g
                                                 select g.First();
    IEnumerable<PersonAddresses> businessAddresses = from address in addresses
                                                     where address.AddressType == "BusinessAddress"
                                                     group address by address.id into g
                                                     select g.First();
    IEnumerable<PersonData> data = from person in persons
                                   join tmp1 in homeAddresses on person.id equals tmp1.id into ha
                                   join tmp2 in businessAddresses on person.id equals tmp2.id into ba
                                   from homeAddress in ha.DefaultIfEmpty()
                                   from businessAddress in ba.DefaultIfEmpty()
                                   select new PersonData {
                                     id = person.id,
                                     Name = person.name,
                                     HomeAddress = homeAddress == null
                                       ? null
                                       : new Address {
                                         City = homeAddress.City,
                                         State = homeAddress.State
                                       },
                                     BusinessAddress = businessAddress == null
                                       ? null
                                       : new Address {
                                         City = businessAddress.City,
                                         State = businessAddress.State
                                       },
                                   };
