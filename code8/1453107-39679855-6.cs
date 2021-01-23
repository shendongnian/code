    private static Task<object> CallGetByReflection(IFoo foo, IBar bar)
    {
        var method = typeof(IFoo).GetMethod(nameof(IFoo.Get));
        var generic = method.MakeGenericMethod(bar.GetType());
        return generic.InvokeAsync(foo, new[] {bar});
    }
