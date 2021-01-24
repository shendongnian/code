    public class FooController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Object item)
        {
            if (item == null) return BadRequest();
            var newItem = new Object(); // create the object to return
            if (newItem != null) return Ok(newItem);
            else return NotFound();
        }
    }
