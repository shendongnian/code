    public partial class Form1:Form
    {
        public Form1()
        {
            InitializeComponent();
            userControl1.DataSaved += (sender, e) => { userControl2.RefreshGrid(); }; // Attach event
        }
    }
    class UserControl1 : UserControl
    {
        public event EventHandler DataSaved;
        private void SaveData() // call this when user saves data
        {
            InsetDataToDb(); // real insert to db
            var handler = DataSaved;
            if (handler != null)
                handler(this, EventArgs.Empty); // call event handler
        }
    }
    class UserControl2 : UserControl
    {
        public void RefreshGrid() 
        {
            // refresh data source of grid view
            dataGridView.DataSource = GetDataSource();
        }
    }
