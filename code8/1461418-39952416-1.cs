    protected void Button1_Click(object sender, EventArgs e)
    {
        var pr = new
        {
            Product = new[]
            {
                new Product
                {
                    Id = 10,
                    FirstName = "John",
                    LastName = "ab",
                    Address  = "My Add1"
                }
            }
        };
        string json = JsonConvert.SerializeObject(pr,Formatting.Indented);
        System.IO.File.WriteAllText(@"d:\abcjson.json", json);
    }
