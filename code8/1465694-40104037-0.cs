        public class MyDataSource()
        {
            public int Checklist { get; set; }
            public bool Cek22
            {
                get { return Checklist == 1; }
            }
        }
        private void ExplainADevExpressGrid()
        {
            List<MyDataSource> dataSource = new List<MyDataSource>();
            dataSource.Add(new MyDataSource());
            myGrid.DataSource = dataSource;
        }
