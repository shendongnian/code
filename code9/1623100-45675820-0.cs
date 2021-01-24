    var properties = typeof(Properties.Resources).GetProperties(
        System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic |
        System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static);
    foreach (var propertyInfo in properties)
    {
        var s = propertyInfo.Name;
        if(s != "ResourceManager" && s != "Culture")
        {
            MessageBox.Show(s);
        }
    }
