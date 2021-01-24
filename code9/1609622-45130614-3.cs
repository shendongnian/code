    var person = Peoples.Select(person => new PersonTotal
                                {
                                    Id = person.ID,
                                    Name = person.Name,
                                    Bought = person.Purchases.Sum(p => pu.Quantity),
                                    Referred = person.Referrals.Sum(r => r.Quantity)
                                });
