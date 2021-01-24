    public Country Update(Country country)
    {
        using (var dbContext =new DbContext())
        {
            var countryToUpdate = dbContext.Countries.SingleOrDefault(c => c.Id == country.Id);
            countryToUpdate.Cities.Clear();
            foreach (var city in country.Cities)
            {
                var existingCity =
                    dbContext.Cities.SingleOrDefault(
                        t => t.Id.Equals(city.cityId)) ??
                    dbContext.Cities.Add(new City
                    {
                        Id = city.Id,
                        Name=city.Name
                    });
                countryToUpdate.Cities.Add(existingCity);
            }
            dbContext.SaveChanges();
            return countryToUpdate;
        }
    }
