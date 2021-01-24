    var type = typeof(MyClass);
    var prop = type.GetProperty("Simple", BindingFlags.NonPublic | BindingFlags.Instance);
    var action = new Action<object>((o) => Console.WriteLine("Invoked with {0}", o));
    var delegateInsrtance = Delegate.CreateDelegate(prop.PropertyType, action.Target, action.Method);
    var obj = new MyClass();
    prop.SetValue(obj, delegateInsrtance);
