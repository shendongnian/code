    // Maybe you should give a better name to this...
    public interface IAllowedParamType { }
    // Inherit all the possible classes with that
    public class Parent : IAllowedParamType
    {
        string Name { get; set; }
        bool HasChildren { get; set; }
        int Age { get; set; }
    }
    public class Child : IAllowedParamType
    {
        string Name { get; set; }
        int Age { get; set; }
    }
    // Filter the interface on the 'where'
    public class DataController<TObject> where TObject : class, IAllowedParamType
    {
        protected DbContext _context;
        public DataController(DbContext context)
        {
            _context = context;
        }
    }
    public class FormController<TObject> where TObject : class, IAllowedParamType
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
    public class GenericForm<TObject> : Form where TObject : class, IAllowedParamType
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
