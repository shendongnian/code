    // put this into window constructor
    var dp = DependencyProperty.RegisterAttached("SomeName", typeof(object), typeof(MainWindow));            
    SetValue(dp, "test"); // even trying to set value                      
    var fromNameMethod = typeof(DependencyProperty).GetMethod("FromName", BindingFlags.Static | BindingFlags.NonPublic);
    var a = (DependencyProperty) fromNameMethod.Invoke(null, new object[] { "SomeName", typeof(MainWindow) });
    var value = GetValue(a); // "test
