    foreach (Type item in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                     .Where(mytype => mytype.GetInterfaces().Contains(typeof(IConfigInterface)))) 
    {
        classes.Add(Activator.CreateInstance(item));
    }
