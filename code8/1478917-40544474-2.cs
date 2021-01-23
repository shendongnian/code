            public partial class Form1 : Form
    {
        BindingSource _customers = GetCustomerList();
        public BindingSource Customers
        {
            get { return _customers; }
            set { _customers = value; }
        }
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = Customers;
            LoadDataGridOrderFromFile("myDataGrid.xml", dataGridView1.Columns);
        }
        private static BindingSource GetCustomerList()
        {
            BindingSource customers = new BindingSource();
            customers.Add(new Customer() { Firstname = "John", Lastname = "Doe", Age = 28 });
            customers.Add(new Customer() { Firstname = "Joanne", Lastname = "Doe", Age = 25 });
            return customers;
        }
        static object fileAccessLock = new object();
        private static void SaveDataGridOrderToFile(string path, DataGridViewColumnCollection colCollection)
        {
            lock (fileAccessLock)
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataGridViewColumnCollectionProxy));
                xmlSerializer.Serialize(fs, new DataGridViewColumnCollectionProxy(colCollection));
            }
        }
        private static void LoadDataGridOrderFromFile(string path, DataGridViewColumnCollection colCollection)
        {
            if (File.Exists(path))
            {
                lock (fileAccessLock)
                    using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataGridViewColumnCollectionProxy));
                    DataGridViewColumnCollectionProxy proxy = (DataGridViewColumnCollectionProxy)xmlSerializer.Deserialize(fs);
                    proxy.SetColumnOrder(colCollection);
                }
            }
        }
        private void dataGridView1_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SaveDataGridOrderToFile("myDataGrid.xml", dataGridView1.Columns);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnDisplayIndexChanged +=dataGridView1_ColumnDisplayIndexChanged;
        }
    }
