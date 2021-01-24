    public static class Constants
    {
    #if FOO
        public static ConstantsFoo Current { get; } = new ConstantsFoo();
    #elif BAR
        public static ConstantsBar Current { get; } = new ConstantsBar();
    #endif
    }
    //...snip
    var element = driver.GetElement(Constants.Current.SomeSelector);
