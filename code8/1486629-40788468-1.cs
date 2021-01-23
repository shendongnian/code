    public async Task<IActionResult> Index()
    {           
        List<LngLat> routeCoordinates = await _context.Trips.Select(c=> new LngLat {lat = c.latitude, lng = c.longitude })
        //Serialize your routeCoordiamte with Json.Net
       string routeCoordinatesJs = JsonConvert.SerializeObject(routeCoordinates, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
        return View(routeCoordinatesJs);
    }
