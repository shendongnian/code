    public class Parent
    {
        string Name { get; set; }
        bool HasChildren { get; set; }
        int Age { get; set; }
    }
    public class Child
    {
        string Name { get; set; }
        int Age { get; set; }
    }
    public class DataController<TObject> where TObject : class
    {
        protected DbContext _context;
        public DataController(DbContext context)
        {
            _context = context;
        }
    }
    public class FormController<TObject> where TObject : class
    {
        private DataController<TObject> _dataController;
        public FormController(Button btn, DataController<TObject> dataController)
        {
            _dataController = dataController;
            btn.Click += new EventHandler(btnClick);
        }
        private void btnClick(object sender, EventArgs e)
        {
            GenericForm<TObject> form = new GenericForm<TObject>();
            form.ShowDialog();
        }
    }
    public class GenericForm<TObject> : Form where TObject : class
    {
        public TObject GenericType { get; set; }
        public GenericForm()
        {
            Paint += GenericForm_Paint;
        }
        private void GenericForm_Paint(object sender, EventArgs e)
        {
            MessageBox.Show(typeof(TObject).ToString());
            // If you want to instantiate:
            GenericType = (TObject)Activator.CreateInstance(typeof(TObject));
        }
    }
