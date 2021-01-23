    public partial class YourForm : Form
    {
        private readonly BindingList<Person> _data;
        public YourForm()
        {
            InitializeComponent();
            // Create empty collection/datasource
            _data = new BindingList<Person>();
            // This line will generate columns automatically if
            // DataGridView.AutoGenerateColumns = true (by default it is true)
            this.yourDataGridView.DataSource = _data;
        }
    }
