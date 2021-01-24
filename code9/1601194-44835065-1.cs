    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponents();
            this.myItems= new BindingListView<MyClass>(this.components);
            this.bindingSource1.DataSource = this.myItems;
        }
        private readonly BindingListView<MyClass> myItems;
        private void InitialeDataGridView
        {
            IEnumerable<MyClass> dataToShow = ...
            this.myItems = dataToShow.ToList();
        }
        private void Form1_Load(object sender, ...)
        {
            this.InitializeDataGridView();
        }
        private void button1_click(object sender, ...)
        {
            IEnumerable<MyClass> editedData = (BindingListView<MyClass>)this.bindingSource1.DataSource;
            ProcessEditedData(editedData);
        }
    }
