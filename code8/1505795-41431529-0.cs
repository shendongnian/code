    var obj = (YourType)JsonConvert.DeserializeObject(
                       json,
                       typeof(YourType),
                       new JsonSerializerSettings()
                       {
                           TypeNameHandling = TypeNameHandling.Auto,
                           MissingMemberHandling=MissingMemberHandling.Ignore
                       });
