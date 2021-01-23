    string content = File.ReadAllText(path);
    if (JsonUtils.IsJsArray(content))
    {
        IEnumerable<Phone> phones = JsonSerializer.DeserializeFromString<List<Phone>>(json);
    }
    else if (JsonUtils.IsJsObject(content))
    {
        Phone phone = JsonSerializer.DeserializeFromString<Phone>(json);
    }
