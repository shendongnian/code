    public partial class MyForm : Form
    {
        private readonly MyValidation _validation;
        public Myform()
        {
            InitializeComponent();
            _validation = new MyValidation(errorProvider1);
        }
        //TODO: use _validation instead of inherited validation logic.
    }
