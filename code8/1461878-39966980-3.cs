        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            chart1 = new Chart();
            LinearAxis ax1 = new LinearAxis
            {
                Title = "First Axis",
                ShowGridLines = true,
                Orientation = AxisOrientation.Y,
                Minimum = 0
            };
            Binding b1 = new Binding();
            b1.Source = ax1;
            b1.Path = new PropertyPath("ActualInterval");
            Binding b2 = new Binding();
            b2.Source = ax1;
            b2.Path = new PropertyPath("ActualMaximum");
            LinearAxis ax2 = new LinearAxis
            {
                Title = "Second Axis",
                ShowGridLines = true,
                Orientation = AxisOrientation.Y
            };
            ax2.SetBinding(LinearAxis.IntervalProperty, b1);
            ax2.SetBinding(LinearAxis.MaximumProperty, b2);
            chart1.Axes.Add(ax1);
            chart1.Axes.Add(ax2);
            PointCollection pc = new PointCollection();
            pc.Add(new Point { X = 1, Y = 10 });
            pc.Add(new Point { X = 2, Y = 20 });
            pc.Add(new Point { X = 3, Y = 30 });
            pc.Add(new Point { X = 4, Y = 40 });
            ColumnSeries series = new ColumnSeries();
            series.ItemsSource = pc;
            series.DependentValuePath = "Y";
            series.IndependentValuePath = "X";
            chart1.Series.Add(series);
            AddChild(chart1);
        }
