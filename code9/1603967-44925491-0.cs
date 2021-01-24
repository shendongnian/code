    [HttpPost]      
    public async Task<IActionResult> MyAction([FromBody] Person person)
    {
        var myName = person.Name;
    }
    public class Person
    {
        public string Name {get;set;}
        public string Address {get;set;}
    }
