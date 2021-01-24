    var message = new Tuple<string, Tuple<int, HashSet<double>>>("test", new Tuple<int, HashSet<double>>(2, new HashSet<double>() { 2d, 3d }));            
    var msg = JObject.FromObject(message);
    msg["_type"] = message.GetType().AssemblyQualifiedName;
    var notification = msg.ToString();
    var parsed = JObject.Parse(notification);
    var type = Type.GetType(parsed["_type"].Value<string>());
    var back = JsonConvert.DeserializeObject(notification, type);
    // all is fine here
