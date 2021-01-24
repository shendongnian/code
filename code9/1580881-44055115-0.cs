    var obj = new []
    {
        new {
            userId = "User1",
            orderNUmber = 0,
            customerId = new [] { "Foo", "Bar", "Woot" }
        },
        new {
            userId = "User2",
            orderNUmber = 0,
            customerId = new [] { "Foo", "Bar", "Woot" }
        },
    };
    var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);
    string UserId = result[0].userId.Value;
