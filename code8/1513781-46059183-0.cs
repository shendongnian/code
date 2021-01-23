    class CarsController {
        // [HttpGet("/api/experimental/cars/")]
        [HttpGet("/api/experimental/cars/{carId}")]
        public Task<IEnumerable<Car>> CarById([FromRoute] string carId)
        {
            if (carId == null)
                return GetAllCars();
            else
                return GetCarWithId(carId);
        }
        // [HttpGet("/api/experimental/cars/{nameFilter?}")]
        [HttpGet("/api/experimental/cars/{nameFilter?}/{rating?}")]
        public Task<IEnumerable<Car>> CarsByNameAndRatingFilter([FromQuery] string nameFilter = "", [FromQuery] int rating = 1)
        {
            // TODO Validate the combination of query string parameters for your specific API/business rules.
            var filter = new Filter {
                NameFilter = nameFilter,
                Rating = rating
            };
            return GetCarsMatchingFilter(filter);
        }
    }
