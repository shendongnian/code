    public static LoaderView Create(ExampleDependency dependency)
    {
        var model = dependency ?? throw new ArgumentNullException(nameof(dependency));
        NSBundle.MainBundle.LoadNibNamed(nameof(LoaderView), null, out var array);
        var view = NSArray.FromArray<NSObject>(array).OfType<LoaderView>().FirstOrDefault();
        view.Initialize(model);
        return view;
    }
    private void Initialize(ExampleDependency dependency)
    {
        _privateField1 = dependency.Value1;
        _privateField2 = dependency.Value2;
        _privateField3 = dependency.Value3;
    }
