    public class MyConverter
    {
        public IList Map
        {
            get { return (IList)GetValue(MapProperty); }
            set { SetValue(MapProperty, value); }
        }
    
        public static readonly DependencyProperty MapProperty =
            DependencyProperty.Register("Map", typeof(IList),
            typeof(MyConverter), new PropertyMetadata(null));
    
        public MyConverter 
        {
            // SetValue causes DependencyProperty precedence issue so bindings 
            // will not work. 
            // WPF supports SetCurrentValue() which solves this but UWP does not 
            this.SetValue(MapProperty, new List<object>());
        }
    }
