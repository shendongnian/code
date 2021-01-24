     public class FormModel
     {
            public int Id { get; set; }
            public string Title{ get; set; }
            public string Url { get; set; }
            public bool IsDeleted { get; set; }
            public IFormFile File { get; set; }
     }
     [HttpPost]
     public IActionResult Post([FromForm] FormModel formModel)
     {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //** your server side code **//
            return Ok();
      }
