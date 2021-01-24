    var props = property.Split(",");
    ... //this code stays the same
    foreach(string prop in props) {
        var propNameAndDirection = prop.Split(" ");
        PropertyInfo pi = type.GetProperty(propNameAndDirection[0]);
        ... //continue as necessary, using propNameAndDirection[1] 
        ... //to decide OrderBy or OrderByDesc call
