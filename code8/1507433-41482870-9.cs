    using (var context = new Context())
        {
            // getting entity from db, reflect it to dto
            var countryDTO = context.Countries.FirstOrDefault(x => x.Id == 1).ToDTO<CountryData>();
    
            // add new city to dto 
            countryDTO.Cities.Add(new CityData 
                                      { 
                                          CountryId = countryDTO.Id, 
                                          Name = "new city", 
                                          Population = 100000 
                                      });
    
            // change existing city name
            countryDTO.Cities.FirstOrDefault(x => x.Id == 4).Name = "another name";
    
            // retrieving original entity from db
            var country = context.Countries.FirstOrDefault(x => x.Id == 1);
    
            // mapping 
            AutoMapper.Mapper.Map(countryDTO, country);
    
            // save and expecting ef to recognize changes
            context.SaveChanges();
        }
