    public class MyClass
    {
        public bool IsDesignMode { get;private set; }
        public MyClass()
        {
            IsDesignMode = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }
    }
