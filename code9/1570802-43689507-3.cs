    string json = File.ReadAllText(@"C:\json\data.json");
    
    // Parse the JSON into a list of Users
    List<User> users = JObject.Parse(json)["users"]
       .Select(t => t.ToObject<User>())
       .ToList();
    // Generate pair-wise combinations of users
    // and check for intersection of their tags.
    // If two or more common tags, add the pairing to a list
    List<Pairing> pairings = new List<Pairing>();
    for (int i = 0; i < users.Count; i++)
    {
        User user1 = users[i];
        for (int j = i + 1; j < users.Count; j++)
        {
            User user2 = users[j];
            var commonTags = user1.Tags.Intersect(user2.Tags).ToList();
            if (commonTags.Count > 1)
            {
                pairings.Add(new Pairing
                {
                    User1 = user1,
                    User2 = user2,
                    CommonTags = commonTags
                });
            }
        }
    }
    // Write out the results
    Console.WriteLine("Pairs of users sharing two or more tags with each other:");
    Console.WriteLine();
    foreach (Pairing p in pairings)
    {
        Console.WriteLine(string.Format("{0} (id {1}) and {2} (id {3}) have ({4}) in common.",
         p.User1.Name, p.User1.Id, p.User2.Name, p.User2.Id, string.Join(", ", p.CommonTags)));
    }
