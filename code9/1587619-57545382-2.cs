    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            EntityProperties pp = new EntityProperties()
            {
                myProperties = new List<MyProperty>()
                {
                    new MyProperty() { Type = MyProperty.PropertyType.String, StringValue = "simple", PropertyName = "EntityType" },
                    new MyProperty() { Type = MyProperty.PropertyType.Number, NumberValue = 123, PropertyName = "EntityID" }
                }
            };
    
    
            _propertyGrid.SelectedObject = pp;
    
            _propertyGrid.AutoGenerateProperties = true;
        }
        }
