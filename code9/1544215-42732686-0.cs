    public partial class BindingBench : Window
    {
        CollectionViewSource dbViewsource = new CollectionViewSource();
        SimplyDataSet _dataSet = new SimplyDataSet();
        public BindingBench()
        {
            InitializeComponent();
            _dataSet.TableA.Columns.Add(new DataColumn("FullName", typeof(string)));
            SimplyDataSet.TableARow arow = _dataSet.TableA.AddTableARow("Z", 0.0);
            arow = _dataSet.TableA.AddTableARow("X", 1.0);
            arow = _dataSet.TableA.AddTableARow("Y", 2.0);
            dbViewsource.Source = _dataSet  //This could possibly be _dataSet.GetDefaultView()
            DataContext = dbViewSource.View;
        }
        public DataTable TableA
        {
            get { return _dataSet.TableA; }
        }
    }
