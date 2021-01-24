        List<string> MasterListCars = new List<string>();
        List<string> TempListCars = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            MasterListCars.Add("Audi");
            MasterListCars.Add("BMW");
            MasterListCars.Add("Mercedes");
            Cb1.ItemsSource = MasterListCars;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TempListCars = MasterListCars.Where(x => x != Cb1.SelectedItem.ToString()).ToList();
            cb2.ItemsSource = MasterListCars;
        }
