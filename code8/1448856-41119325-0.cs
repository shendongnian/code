    public void UnitsChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
         //do stuff with e.OriginalSource
         Console.WriteLine(0);
    }
    FrameworkElementFactory factory3 = new FrameworkElementFactory(typeof(DoubleUpDown));
                        factory3.SetValue(DoubleUpDown.ValueProperty, 10.0);
                        factory3.AddHandler(DoubleUpDown.ValueChangedEvent, new RoutedPropertyChangedEventHandler<object>(UnitsChanged));
