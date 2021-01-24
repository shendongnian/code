    class MyClass
    {
        public int Property { get; set; }
    }
    var dict = new Dictionary<PropertyInfo, dynamic>();
    var propertyInfo = typeof(MyClass).GetProperty(nameof(MyClass.Property));
    dict.Add(propertyInfo, Activator.CreateInstance(typeof(List<>).MakeGenericType(propertyInfo.PropertyType)));
    
