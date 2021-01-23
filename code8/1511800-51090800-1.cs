    [HttpPost]
    
    public IActionResult  SetMessagesReadFlag([FromBody] Dummy data)
    {
        ....
        return Json(true);
    }
        
    public class Dummy
    {
        public List<Guid> MessageIds { get; set; }
        
        public bool Read { get; set; }
    }
