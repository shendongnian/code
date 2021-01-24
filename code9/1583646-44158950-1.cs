    public partial class SearchView : UserControl
    {
        public SearchView()
        {
            InitializeComponent();
            DataContextChanged += SearchView_DataContextChanged;
            DataContext = new SearchViewModel<Product>();
        }
        private void SearchView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                Type genericType = e.NewValue.GetType();
                //check the DataContext was set to a SearchViewModel<T>
                if (genericType.GetGenericTypeDefinition() == typeof(SearchViewModel<>))
                {
                    //...and create a TextBox for each property of the type T
                    Type type = genericType.GetGenericArguments()[0];
                    var properties = type.GetProperties();
                    foreach(var property in properties)
                    {
                        TextBox textBox = new TextBox();
                        Binding binding = new Binding(property.Name);
                        if (!property.CanWrite)
                            binding.Mode = BindingMode.OneWay;
                        textBox.SetBinding(TextBox.TextProperty, binding);
                        rootPanel.Children.Add(textBox);
                    }
                }
            }
        }
    }
