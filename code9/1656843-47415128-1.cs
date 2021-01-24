        public ObservableCollection<Point> ObservablePoints
        {
            get { return (ObservableCollection<Point>)GetValue(ObservablePointsProperty); }
            set { SetValue(ObservablePointsProperty, value); }
        }
        public static readonly DependencyProperty ObservablePointsProperty =
            DependencyProperty.RegisterAttached(
                "ObservablePoints",
                typeof(ObservableCollection<Point>),
                typeof(LineGraph),
                new PropertyMetadata(
                    new ObservableCollection<Point>(),
                    (d, e) =>
                        {
                            var linePlot = (LineGraph)d;
                            var updateAction = new NotifyCollectionChangedEventHandler(
                                (o, args) =>
                                    {
                                        if (linePlot != null)
                                        {
                                            InteractiveDataDisplay.WPF.Plot.SetPoints(linePlot.polyline, new PointCollection((ObservableCollection<Point>)o));
                                        }
                                    });
                            if (e.OldValue != null)
                            {
                                var coll = (INotifyCollectionChanged)e.OldValue;
                                coll.CollectionChanged -= updateAction;
                            }
                            if (e.NewValue != null)
                            {
                                var coll = (INotifyCollectionChanged)e.NewValue;
                                coll.CollectionChanged += updateAction;
                                if (linePlot != null)
                                {
                                    InteractiveDataDisplay.WPF.Plot.SetPoints(linePlot.polyline, new PointCollection((ObservableCollection<Point>)e.NewValue));
                                }
                            }
                        }));
