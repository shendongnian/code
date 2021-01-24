    JArray users = (JArray)JObject.Parse(json)["users"];
    // Generate pair-wise combinations of users
    // and check for intersection of their tags.
    // If two or more common tags, add both users to a hash set
    HashSet<JObject> result = new HashSet<JObject>();
    for (int i = 0; i < users.Count; i++)
    {
        JObject user1 = (JObject)users[i];
        for (int j = i + 1; j < users.Count; j++)
        {
            JObject user2 = (JObject)users[j];
            if (user1["tags"].Select(t => t.ToString())
                .Intersect(user2["tags"].Select(t => t.ToString()))
                .Count() > 1)
            {
                result.Add(user1);
                result.Add(user2);
            }
        }
    }
    Console.WriteLine("All users that share two or more tags with another user:");
    Console.WriteLine();
    foreach (JObject user in result)
    {
        Console.WriteLine("id: " + user["id"]);
        Console.WriteLine("name: " + user["name"]);
        Console.WriteLine("tags: " + string.Join(", ", user["tags"]));
        Console.WriteLine();
    }
