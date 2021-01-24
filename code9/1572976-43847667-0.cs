        public MainWindow()
        {
            InitializeComponent();
            // get the reference of the column definition of the main grid, then set your new column definition as required.
            var coldef = MainGrid.ColumnDefinitions;
            coldef.Add(new ColumnDefinition(){Name = "col1", Width=new GridLength(100.0)});
            coldef.Add(new ColumnDefinition() { Name = "col2", Width = new GridLength(100.0) });
            coldef.Add(new ColumnDefinition() { Name = "col2", Width = new GridLength(100.0) });
            // now add the child grids dynamically as many as you like.
            for (var i = 0; i < 2; ++i)
            {
                var  colour1 = (byte)(50 * i);
                var colour2 = (byte)(100 * i);
                var grid1 = new Grid()
                {
                    Background = new SolidColorBrush(Color.FromRgb(100, colour1, colour2)),
                };
                grid1.SetValue(Grid.ColumnProperty, i);
                // get the reference to the row definition the child grid, then set the rows as required.
                var rowDef = grid1.RowDefinitions;
                rowDef.Add(new RowDefinition() { Name = "Row1", Height = new GridLength(100.0) });
                rowDef.Add(new RowDefinition() { Name = "Row2", Height = new GridLength(100.0) });
                // add nesting child grids as many as you like.
                for (var j = 0; j < 1; j++)
                {
                    var r = (byte)(50 * i);
                    var g = (byte) (100 * i);
                    var grid2 = new Grid()
                    {
                        Background = new SolidColorBrush(Color.FromRgb(r, g, 255)),
                    };
                    grid2.SetValue(Grid.RowProperty, 0);
                    // add grid 3 to grid 2
                    grid1.Children.Add(grid2);
                }
                // Add grid1 to main grid.
                MainGrid.Children.Add(grid1);
            }
        }
