    [HttpGet("list")]
    public IActionResult List() {
        
        var cars = context.Cars.AsEnumerable();
        var models = cars.Select(car => new CarModel {
                                    markName = car.markName,
                                    modelName = car.modelName, 
                                    year = car.year,
                                    id = car.id,
                                    photo = Url.RouteUrl("CarPhoto", new { id = car.id })
                                }).ToList();
    
        return Ok(models);
    }
    [HttpGet("{id}/photo", Name = "CarPhoto")]
    public IActionResult GetPhoto(int id) {
        string path = "blalblabla"
        Byte[] b = System.IO.File.ReadAllBytes(path);         
        return File(b, "image/jpeg");
    }
