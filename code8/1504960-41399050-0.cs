    MetadataIcons mi = new MetadataIcons();
    Type me = mi.GetType();
    PropertyInfo[] pi = me.GetProperties();
    string somevalue = "";
    foreach (var property in pi){
        if (property.Name.ToLower().Equals(prop.ToLower())){
            somevalue = property.GetValue(prop).ToString();}
    }
    return somevalue;
