    public static class Constants
    {
        static Constants()
        {
    #if FOO
            Current = new ConstantsFoo();
    #elif BAR
            Current = new ConstantsBar();
    #endif
        }
        public static ConstantsBase Current { get; private set; }
    }
    //...snip
    var element = driver.GetElement(Constants.Current.SomeSelector);
