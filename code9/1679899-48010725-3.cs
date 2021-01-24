    // result query
    var result = leftJoin2.OrderBy(r => r.PersonID).ThenBy(r => r.CarID);
    var personsWithCars = new List<PersonDTO>(); // this is the result list
    int personId = -1;
    // Iterating over the result of query. 
    foreach ( var row in result )
    {
        var carDTO = new CarDTO { ID = row.CarID, CarNumber = row.CarNumber };
        if ( row.PersonID != personId )
        {
            // if we reach the row for another person, 
            // then we must create new PersonDTO and add it to resultList(personsWihCars)
            var personDTO = new PersonDTO
                            {
                                ID = row.PersonID, 
                                Name = row.PersonName, 
                                Cars = new List<CarDTO> { carDTO }
                            };
            personsWithCars.Add(personDTO);
            personId = row.PersonID; // remember the ID of last processed person
        }
        else
        {
            // we processing the row for the same person as previous (last added)
            // just add carDTO to its Cars
            personsWithCars.Last().Cars.Add(carDTO);
        }
    }
