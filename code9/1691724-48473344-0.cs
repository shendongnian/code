    var jsonType = ParseJson(payload);
    switch (jsonType.GetType().FullName)
    {
       case "YourAssembly.Question": {Question question = new JavaScriptSerializer().Deserialize<Question>(payload); break;}
       case "YourAssembly.Answer": ...
       case "YourAssembly.Comment": ...
    }
