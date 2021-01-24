    public static void myMethod(Renderer[] renderers)
    {
        print(string.Join(",", renderers.Where(IsVisible).Select(r => r.name)));
        print("--");
    }
