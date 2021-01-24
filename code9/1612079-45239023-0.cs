    public static readonly BindableProperty TestProperty = BindableProperty.Create(nameof(Test), typeof(int), typeof(ExtendedEntry), 0, BindingMode.TwoWay, propertyChanged: TestChanging);
    
    public int Test
    {
        get { return (int)GetValue(TestProperty); }
        set { SetValue(TestProperty, value); }
    }
    
    private static void TestChanging(BindableObject bindable, object oldValue, object newValue)
    {
        var ctrl = (ExtendedEntry)bindable;
        ctrl.Test = (int)newValue;
    }
