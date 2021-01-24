    public partial class MainForm : Form
    {
        private BindingSource bindingSource = new BindingSource();
		
        List<YourData> yourData = new List<YourData>();
        public MainForm()
        {
            InitializeComponent();
            
            bindingSource.DataSource = yourData;
			
            dgv.DataSource = bindingSource;
        }
    }
