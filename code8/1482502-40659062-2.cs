    [HttpPost]
    public async Task<Member> Create([FromBody] string payload)
    {
        var s = await Request.Content.ReadAsStringAsync();
        if (payload == null)
        {
            throw new ArgumentNullException(nameof(payload));
        }
        Console.WriteLine(payload);
        Console.WriteLine(s);
        return null;
    }
