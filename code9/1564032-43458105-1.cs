    public class myclass
    {
        public DataSet dataSet = new DataSet();
        public DataTable dt1;
        public DataTable dt2;
    
        public ObservableCollection<double> values1;
        public ObservableCollection<double> values2;
        public myclass() {
            values1.CollectionChanged += values1Changed;
        }
    
        public void CreateTables()
        {
            // Create the DataSet
            
            // Create the Data Tables
            dt1 = new DataTable();
            dt2 = new DataTable();
    
            dataSet.Tables.Add(dt1);
            dataSet.Tables.Add(dt1);
    
            chart1.DataSource = dataSet;
        }
    
        private void values1Changed(object sender, NotifyCollectionChangedEventArgs args)
        {
            //Get somevalue (what changed)
            dt1.Rows.Add(somevalue);
    
            chart1.DataBind();
        }
    }
