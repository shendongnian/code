    public class MyCustomControl : ItemsControl
    {
        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
        }
        public ViewBase MyView
        {
            get { return (ViewBase)GetValue(MyViewProperty); }
            set { SetValue(MyViewProperty, value); }
        }
        public static readonly DependencyProperty MyViewProperty =
            DependencyProperty.Register("MyView", typeof(ViewBase), typeof(MyCustomControl), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnMyViewChanged)));
        private static void OnMyViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MyCustomControl)d).HasCustomView = e.NewValue != null;
        }
        // readonly property to support the Trigger in the ControlTemplate in order to exchange the ListView.View
        public bool HasCustomView
        {
            get { return (bool)GetValue(HasCustomViewProperty); }
            private set { SetValue(HasCustomViewPropertyKey, value); }
        }
        private static readonly DependencyPropertyKey HasCustomViewPropertyKey =
            DependencyProperty.RegisterReadOnly("HasCustomView", typeof(bool), typeof(MyCustomControl), new PropertyMetadata(false));
        public static readonly DependencyProperty HasCustomViewProperty = HasCustomViewPropertyKey.DependencyProperty;
    }
