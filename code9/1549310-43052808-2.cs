    // POST api/countries
            public async Task<HttpResponseMessage> PostCountry(CountryRequestModel requestModel)
            {
                Country country = _mapper.Map<CountryRequestModel, Country>(requestModel);
                country.CreatedOn = DateTimeOffset.Now;
                country.TenantId = TenantId;
    
                await _countryService.AddAsync(country);
    
                CountryDto countryDto = _mapper.Map<Country, CountryDto>(country);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, countryDto);
                response.Headers.Location = GetCountryLink(country.Id);
    
                return response;
            }
