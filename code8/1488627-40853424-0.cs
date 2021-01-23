    public class MyModel
    {
        public string Key {get; set;}
    }
    [Route("Edit/Test")]
    [HttpPost]
    public void Test(int id, [FromBody] MyModel model)
    {
        ... model.Key....
    }
