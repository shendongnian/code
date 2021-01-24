    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponents();
        }
        private void InitialeDataGridView
        {
            IEnumerable<MyClass> dataToShow = ...
            this.BindingSource1.DataSource = new BindingList<MyClass>(dataToShow.ToList());
        }
        private void Form1_Load(object sender, ...)
        {
            this.InitializeDataGridView();
        }
        private void button1_click(object sender, ...)
        {
            IEnumerable<MyClass> editedData = (BindingList<MyClass>)this.bindingSource1.DataSource;
            ProcessEditedData(editedData);
        }
    }
