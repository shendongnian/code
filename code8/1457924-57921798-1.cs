    string name = httpContext.User.FindFirstValue("Name");
    List<Content> contents = new List<Content>();
    foreach (Claim claim in httpContext.User.FindAll("Content"))
    {
        Content content = Newtonsoft.Json.JsonConvert.DeserializeObject<Content>(claim.Value);
        contents.Add(content);
    };
