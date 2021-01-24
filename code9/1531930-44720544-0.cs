    public class MyForm : Form
    {
        private BindingListView<MyType> MyItems {get; set;}
        public MyForm()
        {
            InitializeComponent();
            
            this.MyItems = new BindingListView<MyType>(this.components);
            // components is created in InitializeComponents
            this.MyBindingSource.DataSource = this.MyItems;
            this.MyDataGridView.DataSource = this.MyBindingSource;
            // assigning the DataPropertyNames of the columns can be done in the designer,
            // however doing it the following way helps you to detect errors at compile time
            // instead of at run time
            this.columnPropertyA = nameof(MyType.PropertyA);
            this.columnPropertyB = nameof(MyType.PropertyB);
            ...
        }
