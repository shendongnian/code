    public IActionResult getCities(int id)
    {
        var cities = new List<City>();
        cities = getCititesFromDatabaseByStateId(id); //call repository
        return Json(citites);
    }
