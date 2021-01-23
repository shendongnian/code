    public static void Navigate<TView, T0, T1>(Func<TView> factory, T0 arg0, T1 arg1)
            where TView : ViewBase<T0, T1> {
        var view = factory();
        view.Initialize(arg0, arg1);
        // ...
    }
