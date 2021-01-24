    FieldInfo fi = (typeof(KeyboardNavigation).GetMember("ShowKeyboardCuesProperty",
        MemberTypes.All, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)[0] as FieldInfo);
    DependencyObject o = new Button();
    DependencyProperty dp = fi.GetValue(o) as DependencyProperty;
    bool value = (bool)o.GetValue(dp); //= false
    o.SetValue(dp, true);
    value = (bool)o.GetValue(dp); // = true
