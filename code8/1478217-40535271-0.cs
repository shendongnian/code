    public partial class Form1 : Form
    {
        private DataStruct[] _data;  // <-- Module level variable
        public Form1()
        {
            InitializeComponent();
            LoadData();  
        }
        private void LoadData()
        {
            // Open file code omitted
            _data = new DataStruct[fileArray.Length];
            // Read data into file omitted
        }
        private void Method1()
        {
            // _data will be accessible here because it is a module-level variable
        }
    }
