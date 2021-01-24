    [Authorize]
    //edit: add another route so that it recognizes id 
    [Route("api/cars/{id}")]
    [Route("api/cars")]
    public HttpResponseMessage Get(string brand = "", string color = "", string id = "")
    {
        //example to get from database based on whichever parameter provided 
        using(var ctx = new DbContext())
        {
            var cars = ctx.Cars
                          .Where(car => String.IsNullOrEmpty(id) || car.Id == id 
                          && String.IsNullOrEmpty(color) || car.Color == color
                          && String.IsNullOrEmpty(brand) || car.Brand == brand);
        //Some stuff
    }
