    public partial class MainWindow : Window
    {
        private void IncrementColumn(UIElement element)
        {
            Grid.SetColumn(element, Grid.GetColumn(element) + 1);
        }
        public MainWindow()
        {
            InitializeComponent();
            scrollPanel.ApplyTemplate();
            var horizontal = scrollPanel.Template.FindName("PART_HorizontalScrollBar", scrollPanel) as ScrollBar;
            var vertical = scrollPanel.Template.FindName("PART_VerticalScrollBar", scrollPanel) as ScrollBar;
            var presenter = scrollPanel.Template.FindName("PART_ScrollContentPresenter", scrollPanel) as ScrollContentPresenter;
            var corner = scrollPanel.Template.FindName("Corner", scrollPanel) as Rectangle;
            var grid = corner.Parent as Grid;
            grid.ColumnDefinitions.Insert(0, new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });
            IncrementColumn(horizontal);
            IncrementColumn(vertical);
            IncrementColumn(corner);
            Grid.SetColumnSpan(presenter, 2);
            var panel = new StackPanel() { Orientation = Orientation.Horizontal };
            panel.Children.Add(new ComboBox());
            panel.Children.Add(new Image());
            Grid.SetRow(panel, 1);
            Grid.SetColumn(panel, 0);
            grid.Children.Add(panel);
        }
    }
