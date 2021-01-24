    public class Myclass: ContentView
    {
        public static readonly BindableProperty TabItemSourceProperty = BindableProperty.Create(
                "TabItemSource",
                typeof(IEnumerable<string>),
                typeof(Myclass)
            );
    
        public IEnumerable<string> TabItemSource { 
            get
            {
                 return (IEnumerable<string>)GetValue(TabItemSourceProperty);
            }
            set
            {
                SetValue(TabItemSourceProperty, value);
            }
        }}
