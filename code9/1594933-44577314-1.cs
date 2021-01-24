    dynamic jsonDynamic = new JavaScriptSerializer().Deserialize<dynamic>(jsonString);
    var list = ((IEnumerable<dynamic>)jsonDynamic["Questions"]).Select(q => new JToken()
    {
        Category = q["Category"],
        Question = q["Question"],
        Answer = q["Answer"]
    });
