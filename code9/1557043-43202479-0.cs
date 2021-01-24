    var properties = typeof(UserData).GetProperties();
    var userValues = new List<string>();
    
    foreach (var user in usersL)
    {
        var values = new List<object>();
        foreach (var property in properties)
        {
            object value = property.GetValue(user, null);
            values.Add(value);
        }
        userValues.Add(string.Join(",", values));
    }
    
    File.WriteAllLines("my_data.txt", userValues);
