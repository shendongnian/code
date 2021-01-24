    string serialized;
    try
    {
        serialized = JsonConvert.SerializeObject(value, new SensitiveDataJsonConverter(value.GetType()));
    }
    catch // Some objects cannot be serialized
    {
        serialized = $"[Unable to serialize object '{key}']";
    }
