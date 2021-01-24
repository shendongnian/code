    XAML:
    <ContentPresenter Content="{Binding Path=DynView}" />
    
    public ViewModel
    {
      public UserControl DynView {get; private set};
      private ModelType _model;
      public ViewModel(ModelType model)
      {
        _model = model;
        DynView = new DynamicControl<ModelType>(_model);
      }
    }
    public class DynamicControl<T> : UserControl 
    {
        static DynamicControl()
        {
            Types[typeof(bool)] = (binding) =>
            {
                CheckBox cb = new CheckBox();
                cb.SetBinding(CheckBox.IsCheckedProperty,binding);
                return cb;
            };
            Types[typeof(String)] = (binding) =>
            {
                TextBox tb = new TextBox();
                tb.SetBinding(TextBox.TextProperty, binding);
                return tb;
            };
           // add additional Types if necessary
        }
       
        private T _model; 
        public DynamicControl(T model)
        {
            _model = model;
            WrapPanel wp = new WrapPanel();
            foreach (PropertyInfo pi in model.GetType().GetProperties())
            {
                Grid g = new Grid();
                g.Margin = new Thickness(5, 5, 25, 5);
                g.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                g.ColumnDefinitions.Add(new ColumnDefinition());
                g.ColumnDefinitions.Add(new ColumnDefinition());
                g.RowDefinitions.Add(new RowDefinition());
                TextBlock tb = new TextBlock() { Text = pi.Name };
                tb.VerticalAlignment = VerticalAlignment.Center;
                Grid.SetColumn(tb, 0);
                Grid.SetRow(tb, 0);
                g.Children.Add(tb);
                System.Windows.FrameworkElement uie = GetUiElement(pi);
                uie.Margin = new Thickness(10, 0, 0, 0);
                uie.VerticalAlignment = VerticalAlignment.Center;
                Grid.SetColumn(uie, 1);
                Grid.SetRow(uie, 0);
                g.Children.Add(uie);
                wp.Children.Add(g);
            }
            this.Content = wp;
        }
        private FrameworkElement GetUiElement(PropertyInfo pi)
        {
            System.Windows.Data.Binding binding = new System.Windows.Data.Binding(pi.Name);
            binding.Source = _model;
            Func<System.Windows.Data.Binding, FrameworkElement> func;
            FrameworkElement uie = null;
            if (Types.TryGetValue(pi.PropertyType, out func))
                uie = func(binding);
            else
                uie = Types[typeof(String)](binding);
            return uie;
        }
        private static Dictionary<Type, Func<System.Windows.Data.Binding, FrameworkElement>> Types = new Dictionary<Type, Func<System.Windows.Data.Binding, FrameworkElement>>();
    }
