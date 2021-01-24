    List<string> cars = new List<string>();
    List<string> cars2 = new List<string>();
    public CarsView()
        {
            InitializeComponent();
    
            cars.Add("Audi");
            cars.Add("BMW");
            cars.Add("Mercedes-Benz");
    
            this.ComboBox1.ItemsSource = cars;
            this.ComboBox2.ItemsSource = cars;
        }
