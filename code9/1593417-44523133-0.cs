    public class MyControl : ContentControl
    {
        public MyControl()
        {           
            this.Loaded += (s,e) => DoSomething();
        }
    
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = (MyControl)d;
            if ( c.IsLoaded )
                c.DoSomething();              
        }
    
        // this will be called only if the control is loaded
        private void DoSomething()
        {
            var value = Value;
            if ( value == null )
            {
                ...
            } else if ( value == string.Empty )
            {
                ...
            } else
            {
            }
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(string), typeof(MyControl),
            new FrameworkPropertyMetadata(default(string),
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal, OnValueChanged));
    
        public string Value
        {
            get { return (string)GetValue(MyControl.ValueProperty); }
            set { SetValue(MyControl.ValueProperty, value); }
        }
        static MyControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyControl), new FrameworkPropertyMetadata(typeof(MyControl)));
        }
    
    }
