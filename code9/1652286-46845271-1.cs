        public class BrushData
        {
            public string Type { get; set; }
            public Brush Brush { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            var lists = new List<BrushData>
            {
                new BrushData {Type = "Theme", Brush = Brushes.Red},
                new BrushData {Type = "Theme", Brush = Brushes.Blue},
                new BrushData {Type = "Theme", Brush = Brushes.Orange},
                new BrushData {Type = "Standard", Brush = Brushes.LightGreen},
                new BrushData {Type = "Standard", Brush = Brushes.LightPink},
                new BrushData {Type = "More Colors...", Brush = null}
            };
            var collection = new ListCollectionView(lists);
            collection.GroupDescriptions.Add(new PropertyGroupDescription("Type"));
            MyComboBox.ItemsSource = collection;
    }
