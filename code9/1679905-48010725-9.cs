    var personsWithCars = result.GroupBy(p => new { p.PersonID, p.PersonName })
                                .Select(g => new PersonDTO
                                             {
                                                 ID = g.Key.PersonID,
                                                 Name = g.Key.PersonName,
                                                 Cars = result.Where(r => r.PersonID == g.Key.PersonID)
                                                              .Select(r => new CarDTO { ID = r.CarID, CarNumber = r.CarNumber })
                                                              .ToList()
                                             });
