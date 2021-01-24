    private ActionResult GetLookupValues<TResult>(Func<TResult> lookupFunc)
    { 
      var listOfValues = lookupFunc();
      return ClientSideDTORender(listOfValues);
    }
    
    public ActionResult GetAllCountries()
    {
      return GetLookupValues<Country>(_blLookups.GetAllCountries);      
    }
    
    public ActionResult GetAllCities(int CountryId)
    {
      return GetLookupValues<City>(() => _blLookups.GetAllCities(CountryId));
    }
