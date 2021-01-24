    var result = myDbContext.Persons
        .Where(person => person.Name == "John Doe")
        .Select(person => new
        {
            PersonId = person.Id,
            PersonName = person.Name,
            AttendedCountryClubs = person.Clubs
                .Where(club => club.Type = ClubType.CountryClub),
        };
