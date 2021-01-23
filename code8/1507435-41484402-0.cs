    var countryDTO = context.Countries.FirstOrDefault(x => x.Id == 1).ToDTO<CountryData>();
    countryDTO.Cities.Add(new CityData { CountryId = countryDTO.Id, Name = "new city 2", Population = 100000 });
    countryDTO.Cities.FirstOrDefault(x => x.Id == 11).Name = "another name";
    
    var country = context.Countries.FirstOrDefault(x => x.Id == 1);
    
    foreach (var cityDTO in countryDTO.Cities)
    {
        if (cityDTO.Id == 0)
        {
            country.Cities.Add(cityDTO.ToEntity<City>());
        }
        else
        {
            AutoMapper.Mapper.Map(cityDTO, country.Cities.SingleOrDefault(c => c.Id == cityDTO.Id)); 
        }
    }
    
    AutoMapper.Mapper.Map(countryDTO, country);
    
    context.SaveChanges();
