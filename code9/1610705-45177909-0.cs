    public class NumberModel
    {
        public int Number { get; set; }
    }
    [HttpPost("method")]
    public IActionResult Method([FromBody] NumberModel model)
    {
        return Ok(model.Number);
    }
