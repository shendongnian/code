    public static void Navigate<T0, T1>(Func<ViewBase<T0, T1>> factory, T0 arg0, T1 arg1) {
        var view = factory();
        view.Initialize(arg0, arg1);
        // ...
    }
