    public partial class ConfiguratorWindow : Window
    {
        public ConfiguratorWindow()
        {
            InitializeComponent();
        }
        private static DependencyProperty DescriptionProperty = DependencyProperty.Register(
            "Description", typeof(string), typeof(ConfiguratorWindow),
            new PropertyMetadata(DescriptionPropertyChanged));
        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }
		
        private static void DescriptionPropertyChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ConfiguratorWindow obj = d as ConfiguratorWindow;
            obj._actual_monitor.Text = (string)e.newValue;
        }
    }
