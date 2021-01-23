    var root = XElement.Parse(xml);
    var json = new JObject(
        root.Elements().Select(x =>
            new JProperty(x.Name.ToString(),
                new JArray(
                    x.Elements().Select(y =>
                        new JObject(
                            y.Elements().Select(z =>
                                new JProperty(z.Name.ToString(),
                                    new JValue(int.Parse(z.Value))
                                )
                            )
                        )
                    )
                )
            )
        )
    ).ToString();
