    public class YourForm
    {
        public YourForm()
        {
            InitializeComponent();
            UpdateSubtitle(); // Display initial value
            dataGridView1.RowsAdded += (sender, args) => UpdateSubtitle();
            dataGridView1.RowsRemoved += (sender, args) => UpdateSubtitle();
        }
        private void UpdateSubtitle()
        {
            lblSubtitle.Text = dataGridView1.RowCount.ToString();
        }
    }
