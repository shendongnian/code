    public ActionResult Index(string title, string city)
    {
        var restaurants = from m in db.Restaurants select m;
        if (!string.IsNullOrEmpty(city))
        {
            restaurants = restaurants.Where(s => s.City.Contains(city));
        }
        if (!string.IsNullOrEmpty(title))
        {
            restaurants = restaurants.Where(x => x.RestaurantName == title);
        }
        var cities = db.Restaurants.OrderBy(x => x.City).Select(x => x.City).Distinct();
        RestaurantVM model = new RestaurantVM()
        {
            Title = title,
            City = city,
            CityList = new SelectList(cities),
            Restaurants = restaurants
        };
        return View(model );
    }
