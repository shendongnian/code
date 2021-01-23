    private ObservableDataSource<Point> data;
        public ObservableDataSource<Point> Data
        {
            get { return data; }
            set
            {
                data = value;
                RaisPropertyChangedEvent("Data");
            }
        }
        public void UpdateplotInformation()
        {
            var list = new List<Point>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Point(i, Math.Sin(i)));
            }
            Data = new ObservableDataSource<Point>(list);
        }
