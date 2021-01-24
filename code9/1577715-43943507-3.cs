    var dict = JArray.Parse(json)
        .Children<JObject>()
        .ToDictionary(jo => (string)jo["Id"], jo => new JObject(jo));
    var root = new JArray();
    foreach (JObject obj in dict.Values)
    {
        JObject parent;
        string parentId = (string)obj["ParentId"];
        if (parentId != null && dict.TryGetValue(parentId, out parent))
        {
            JArray items = (JArray)parent["items"];
            if (items == null)
            {
                items = new JArray();
                parent.Add("items", items);
            }
            items.Add(obj);
        }
        else
        {
            root.Add(obj);
        }
		JProperty depth = obj.Property("depth");
		if (depth != null) depth.Remove();
    }
    Console.WriteLine(root.ToString());
