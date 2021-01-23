    public class Error
    {
        public string Message { get; }
        public int StatusCode { get; }
        public Error(string message, HttpStatusCode statusCode)
        {
            Message = message;
            StatusCode = (int)statusCode;
        }
    }    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
           return Ok(_manager.GetPokemon(id));
        }
        catch (NullReferenceException e)
        {
           var error = new Error(e.Message, HttpStatusCode.NotFound);
           return new JsonResult(error) {StatusCode = error.StatusCode};
        }
    }
