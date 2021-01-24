    public static void Main(string[] args)
    {
        var json = @"{
            ""initdata"":  {
                ""cell"": {
                    ""apn"": ""n"",
                    ""userName"": ""n"",
                    ""password"": ""n"",
                    ""number"": ""n""
                },
                ""wifi"": {
                    ""mode"": ""AP"",
                    ""ssid"": ""m"",
                    ""password1"": "",""
                },
                ""ports"": {
                    ""p1"": ""k"",
                    ""p2"": ""y"",
                    ""p3"": ""5""
                }
            }
        }";
        dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(json, new ExpandoObjectConverter());
        PrepareEnumIds();
        RenameEnumProps(obj as ExpandoObject);
        var shortJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
        Console.WriteLine(shortJson);
    }
    public static void RenameEnumProps(ExpandoObject expando)
    {
        var expandoDict = expando as IDictionary<string, object>;
        var props = new List<string>(expandoDict.Keys);
        for (var i = props.Count - 1; i >= 0; i--)
        {
            var child = expandoDict[props[i]];
            if (child is ExpandoObject)
                RenameEnumProps(child as ExpandoObject);
            if (enumIds.ContainsKey(props[i]))
            {
                expandoDict.Add(enumIds[props[i]], child);
                expandoDict.Remove(props[i]);
            }
        }
    }
    static Dictionary<string, string> enumIds = new Dictionary<string, string>();
    static void PrepareEnumIds()
    {
        foreach (var enumType in new[] { typeof(celle), typeof(wifie), typeof(portse), typeof(initdatae), typeof(settingse) })
            foreach (var enumValue in Enum.GetValues(enumType))
                enumIds.Add(enumValue.ToString(), ((int)enumValue).ToString());
    }
    public enum celle { apn, userName, password, number };
    public enum wifie { mode, ssid, password1 };
    public enum portse { p1, p2, p3 };
    public enum initdatae { cell, wifi, ports };
    public enum settingse { initdata, timers }
