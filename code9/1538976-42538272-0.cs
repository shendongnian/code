     public class BindingProxy : Freezable
    {
        protected override Freezable CreateInstanceCore() { return new BindingProxy(); }
        public static readonly DependencyProperty ContextProperty =
            DependencyProperty.Register("Context", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
        public object Context
        {
            get { return (object)GetValue(ContextProperty); }
            set { SetValue(ContextProperty, value); }
        }
    }
