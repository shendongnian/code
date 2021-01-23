    class Model
    {
        public string payload {get;set;}
    }
    [HttpPost]
    public async Task<Member> Create([FromBody] Model model) // wrap Member in Task and add async keyword
    {
        var s = await Request.Content.ReadAsStringAsync(); // add await here
    
        if (model.payload == null)
        {
            throw new ArgumentNullException(nameof(model.payload));
        }
    
        Console.WriteLine(model.payload);
        Console.WriteLine(s);
    
        return null;
    }
