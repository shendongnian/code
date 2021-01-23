    var newColor = "hello";
    var jtoken = JObject.Parse("{yourinput}");
    
    var colorProperties = jtoken
                          .Descendants()
                          .OfType<JProperty>()
                          .Where(x => x.Name == "color")
                          .ToList();
    foreach (var prop in colorProperties)
    {
        prop.Replace(new JProperty("color", newColor));
    }
    var result = jtoken.ToString();
