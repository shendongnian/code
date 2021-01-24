    public void WriteKeyProperty(Type classType)
    {
        var properties = classType.GetProperties();
        foreach (var property in properties)
        {
            var keyAttribute = property.GetCustomAttribute(typeof(KeyAttribute));
            if (keyAttribute == null) continue;
            const string msg = "The Primary Key for the {0} class is the {1} property";
            Console.WriteLine(msg, classType.Name, property.Name);
        }
    }
