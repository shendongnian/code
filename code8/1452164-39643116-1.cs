    var notification = new Notification()
    {
        Name = "Test",
        Body = "TestBody",
        Subject = "TestSubject",
        Users = "TestUsers",
        Date = DateTime.Now.ToString(),
        Action = new List<Dictionary<string, Dictionary<string, string>>>()
        {
            new Dictionary<string, Dictionary<string, string>>()
            {
                { "key", new Dictionary<string, string>() { { "innerKey", "value" } } }
            }
        }
    };
