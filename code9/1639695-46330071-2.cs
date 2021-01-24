    public static string GetAllProperties(object obj)
    {
        return string.Join(" ", obj.GetType()
                                    .GetProperties()
                                    .Where(p => p.CanRead)
                                    .Where(p => p.GetIndexParameters().Length == 0)
                                    .Select(prop => prop.GetValue(obj)));
    }
    var dynRes = JsonConvert.DeserializeObject<dynamic>(someJson);
    Console.WriteLine(GetAllProperties(dynRes));
