    string json = @"...";
    List<ClientObject> clients = new List<ClientObject>();
    JObject data = JObject.Parse(json);
    foreach (var client in data["clients"].Select(c => c).ToList())
    	clients.Add(client.ToObject<ClientObject>());
