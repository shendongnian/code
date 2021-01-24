    [HttpGet]
            public async Task<IActionResult> GeTask()
            {
                List<Country> countries = Shared.Database.SqlAction.CountriesTable.GetCountries();
                return Ok(countries); 
    }
