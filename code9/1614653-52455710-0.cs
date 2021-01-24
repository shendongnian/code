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
            this.SetValue(MapProperty, new List<object>());
        }
    }
