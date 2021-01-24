    public class Role
    {
        public string Name { get; set; }
    }
    public class Main
    {
        string json = @"{ 'name': 'Admin' }{ 'name': 'Publisher' }";
        IList<Role> roles = new List<Role>();
    
        JsonTextReader reader = new JsonTextReader(new StringReader(json));
        reader.SupportMultipleContent = true;
    
        while (true)
        {
            if (!reader.Read())
                break;
    
            JsonSerializer serializer = new JsonSerializer();
            Role role = serializer.Deserialize<Role>(reader);
            roles.Add(role);
        }
    
        foreach (Role role in roles)
            Console.WriteLine(role.Name);
    }
