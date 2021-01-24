    /// <summary>
    /// Adds a new car model.
    /// </summary>
    /// <param name="model">The model to add</param>
    /// <response code="201">Returns when the car was added successfully and returns the location to the new resource</response>
    /// <response code="400">Invalid Request data.</response>
    /// <response code="409">Car mode already exists.</response>
    /// <returns>The newly added model on success and a list of errors on failure.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CarInputModel), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(SerializableError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.Conflict)]
    public IActionResult AddCar(CarInputModel model) 
    {
    }
    
    /// <summary>
    /// Represents a car
    /// </summary>
    public class CarInputModel {
        /// <summary>
        /// Name of the car
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Model of the car
        /// </summary>
        public string ModelName { get; set; }
    }
