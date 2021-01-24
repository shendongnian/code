        private readonly List<string> _names = new List<string>();
        private Visual _rectangleVisual;
        private Visual _parentVisual;
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 32; i++)
            {
                _names.Add("item " + i);
            }
            ListView.ItemsSource = _names;
            _parentVisual = ElementCompositionPreview.GetElementVisual(ParentCanvas);
            _rectangleVisual = ElementCompositionPreview.GetElementVisual(Arrow);
            var border = VisualTreeHelper.GetChild(ListView, 0) as Border;
            var scrollViewer = border.Child as ScrollViewer;
            var scrollerProperties = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(scrollViewer);
            var offsetExpressionAnimation = _rectangleVisual.Compositor.CreateExpressionAnimation("Scroller.Translation.Y");
            offsetExpressionAnimation.SetReferenceParameter("Scroller", scrollerProperties);
            _rectangleVisual.StartAnimation("Offset.Y", offsetExpressionAnimation);
        }
        private void ListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listViewItem = ListView.ContainerFromItem(ListView.SelectedItem) as ListViewItem;
            var listItemVisual = ElementCompositionPreview.GetElementVisual(listViewItem);
            _parentVisual.Offset = new Vector3(_parentVisual.Offset.X, listItemVisual.Offset.Y, 0);
        }
