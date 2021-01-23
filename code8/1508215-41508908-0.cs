    [HttpPost]
    public IActionResult POST([FromBody] MyObjClass data)
    {
      //Do something with data
      return Ok();
    }
    public class MyObjClass  
    {
        public string StringProperty { get; set; }
        public int IntProperty { get; set; }
        ...
    }
