    var query = doc
        .Root
        .Elements("parameter")
        .Where(parameter => (string) parameter.Element("name") == "CO" &&
                            !string.IsNullOrEmpty((string) parameter.Element("value"));
    var count = query.Count(); // It's not clear why this was Gvalue in your original code
