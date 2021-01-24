    Type t = ItemsSource.GetType();
    if (t.Name == "ObservableCollection`1")
    {
       MethodInfo method = t.GetRuntimeMethod("Move", new Type[] { typeof(Int32), typeof(Int32) });
       method.Invoke(ItemsSource, new object[] { oldIndex, newIndex });
    }
