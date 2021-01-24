    public partial class ButtonDragging
    {
        private Button _mouseDownButton;
        private Point _mouseDownLocation;
        public ButtonDragging()
        {
            InitializeComponent();
            BuildButtonGrid();
        }
        private void BuildButtonGrid()
        {
            const int rows = 5;
            const int columns = 5;
            var starLength = new GridLength(1d, GridUnitType.Star);
            for (var i = 0; i < rows; i++)
                _grid.RowDefinitions.Add(new RowDefinition { Height = starLength });
            for (var i = 0; i < columns; i++)
                _grid.ColumnDefinitions.Add(new ColumnDefinition { Width = starLength });
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    var button = new Button { Content = $@"({i}, {j})", AllowDrop = true };
                    Grid.SetColumn(button, i);
                    Grid.SetRow(button, j);
                    button.PreviewMouseMove += OnButtonMouseMove;
                    button.PreviewMouseLeftButtonDown += OnButtonLeftButtonDown;
                    button.PreviewMouseLeftButtonUp += OnButtonLeftButtonUp;
                    button.Drop += OnButtonDrop;
                    button.Click += OnButtonClick;
                    button.LostMouseCapture += OnButtonLostMouseCapture;
                    _grid.Children.Add(button);
                }
            }
        }
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            _statusLabel.Content = $@"You clicked {(sender as Button)?.Content}!";
        }
        private void ClearPendingDrag()
        {
            _mouseDownButton = null;
            _mouseDownLocation = default(Point);
        }
        private void OnButtonDrop(object sender, DragEventArgs e)
        {
            ClearPendingDrag();
            var source = e.Data.GetData(typeof(object)) as Button;
            if (source == null)
                return;
            var target = (Button)sender;
            if (target == source)
                return;
            var sourceContent = source.Content;
            var targetContent = target.Content;
            // As a proof of concept, this swaps the content of the source and target.
            // Change as necessary to get the behavior you want.
            target.Content = sourceContent;
            source.Content = targetContent;
            _statusLabel.Content = $@"You swapped {sourceContent} with {targetContent}!";
        }
        private void OnButtonLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var button = (Button)sender;
            _mouseDownButton = button;
            _mouseDownLocation = e.GetPosition(button);
            if (!Mouse.Capture(button, CaptureMode.SubTree))
                ClearPendingDrag();
        }
        private void OnButtonLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ClearPendingDrag();
        }
        private void OnButtonMouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDownButton == null)
                return;
            var position = e.GetPosition(_mouseDownButton);
            var distance = position - _mouseDownLocation;
            if (Math.Abs(distance.X) > SystemParameters.MinimumHorizontalDragDistance &&
                Math.Abs(distance.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                var button = (Button)sender;
                var data = new DataObject(typeof(object), button);
                data.SetData("Source", sender);
                DragDrop.DoDragDrop(button, data, DragDropEffects.Move);
                ClearPendingDrag();
            }
        }
        private void OnButtonLostMouseCapture(object sender, MouseEventArgs e)
        {
            ClearPendingDrag();
        }
    }
