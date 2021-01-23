    public partial class ConfiguratorWindow : Window
    {
    public ConfiguratorWindow()
        {
            InitializeComponent();
        }
    private static DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(ConfiguratorWindow), new PropertyMetadata(null, CallBack);
     private static void callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var foo = d as ConfiguratorWindow ;
           now you have access to  foo.Description
        }
    public string Description
        {
            get { return GetValue(DescriptionProperty).ToString(); }
            set { SetValue(DescriptionProperty, value);}
        }
    }
