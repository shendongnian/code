    public partial class MainWindow : Window
    {
        readonly ObservableCollection<ModuleCategoryViewControl> items = new ObservableCollection<ModuleCategoryViewControl>();
        public MainWindow()
        {
            InitializeComponent();
            items.Add(new ModuleCategoryViewControl("Item2", "A", typeof(int)));
            items.Add(new ModuleCategoryViewControl("Item2", "A", typeof(int)));
            items.Add(new ModuleCategoryViewControl("Item3", "A", typeof(int)));
            items.Add(new ModuleCategoryViewControl("Item4", "B", typeof(int)));
            items.Add(new ModuleCategoryViewControl("Item5", "B", typeof(int)));
            ListCollectionView lcv = new ListCollectionView(items);
            lcv.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            comboBox.ItemsSource = lcv;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            items.Add(new ModuleCategoryViewControl("Item6", "A", typeof(int)));
            items.Add(new ModuleCategoryViewControl("Item7", "C", typeof(int)));
        }
    }
