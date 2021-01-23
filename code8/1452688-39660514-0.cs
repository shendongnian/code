    public partial class ConfiguratorWindow : Window
    {
        public ConfiguratorWindow()
        {
            InitializeComponent();
        }
        private static DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(ConfiguratorWindow), new PropertyMetadata(string.empty,CallbackMethod));
        public string Description
        {
            get { return GetValue(DescriptionProperty).ToString(); }
            set {
                    SetValue(DescriptionProperty, value);
                    _actual_monitor.Description = value;
                }
        }
		
	    private void CallbackMethod(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           ConfiguratorWindow obj = d as ConfiguratorWindow ;
		   obj.DescriptionTextBox.Text = (string)e.newValue;
        }
    }
