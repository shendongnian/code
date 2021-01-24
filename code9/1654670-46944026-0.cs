    public partial class MainWindow : Window
    {
        private GridViewColumn Column_1;
        private GridViewColumn Column_2;
        private GridViewColumn Column_3;
        private GridViewColumn Column_4;
    
        public MainWindow()
        {
            InitializeComponent();
    
            DataContext = this;
    
            InitializeColumn1();
            InitializeColumn2();
            InitializeColumn3();
            InitializeColumn4();
    
            SetItemsSource();
        }
    
        private void SetItemsSource()
        {
            Items = new ObservableCollection<MyDataClass>
            {
                new MyDataClass
                {
                    Icon = new BitmapImage(new Uri("https://www.gravatar.com/avatar/b6f0ad4cd865587a782bf697d3b18d18?s=32&d=identicon&r=PG&f=1")),
                    Column1_Content = "Column1 Content",
                    Column2_Content = "Column2 Content",
                    Column3_Content = "Column3 Content",
                    Column4_Content = "Column4 Content"
                }
            };
        }
    
        private void InitializeColumn1()
        {
            var column1Template = new FrameworkElementFactory(typeof(DockPanel));
            var column1TemplateImage = new FrameworkElementFactory(typeof(Image));
            column1TemplateImage.SetValue(WidthProperty, 15d);
            column1TemplateImage.SetValue(HeightProperty, 15d);
            column1TemplateImage.SetBinding(Image.SourceProperty, new Binding("Icon"));
            column1TemplateImage.SetValue(DockPanel.DockProperty, Dock.Left);
            var column1TemplateLabel = new FrameworkElementFactory(typeof(Label));
            column1TemplateLabel.SetBinding(ContentProperty, new Binding("Column1_Content"));
            column1TemplateLabel.SetValue(WidthProperty, 180d);
            column1TemplateLabel.SetValue(FontSizeProperty, 12d);
            column1TemplateLabel.SetValue(HorizontalContentAlignmentProperty, HorizontalAlignment.Left);
            column1TemplateLabel.SetValue(DockPanel.DockProperty, Dock.Left);
    
            column1Template.AppendChild(column1TemplateImage);
            column1Template.AppendChild(column1TemplateLabel);
    
            Column_1 = new GridViewColumn
            {
                Header = "Column1",
                Width = 200,
                CellTemplate = new DataTemplate { VisualTree = column1Template }
            };
        }
    
        private void InitializeColumn2()
        {
            Column_2 = new GridViewColumn
            {
                Header = "Column2",
                Width = 175,
                DisplayMemberBinding = new Binding("Column2_Content")
            };
        }
    
        private void InitializeColumn3()
        {
            Column_3 = new GridViewColumn
            {
                Header = "Column3",
                Width = 100,
                DisplayMemberBinding = new Binding("Column3_Content")
            };
        }
    
        private void InitializeColumn4()
        {
            Column_4 = new GridViewColumn
            {
                Header = "Column4",
                Width = 100,
                DisplayMemberBinding = new Binding("Column4_Content")
            };
        }
        
        private void CreateViewButtonClicked(object sender, RoutedEventArgs e)
        {
            var gridView = new GridView();
            
            gridView.Columns.Add(Column_1);
            gridView.Columns.Add(Column_2);
            gridView.Columns.Add(Column_3);
            gridView.Columns.Add(Column_4);
    
            MyListView.View = gridView;
        }
    
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
            "Items", typeof(ObservableCollection<MyDataClass>), typeof(MainWindow), new PropertyMetadata(default(ObservableCollection<MyDataClass>)));
    
        public ObservableCollection<MyDataClass> Items
        {
            get { return (ObservableCollection<MyDataClass>) GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
    }
