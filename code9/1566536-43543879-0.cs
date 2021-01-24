    public class MyCustomControl : ContentControl
    {
        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
        }
        public MyCustomControl()
        {
            IsEnabledChanged += (s, e) => { /* do something */ };
        }
    }
