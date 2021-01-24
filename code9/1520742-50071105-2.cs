    public class BaseForm : Form
    {
        public BaseForm() {...}
    }
    public class BaseSubForm<T> : Form where T : BaseForm
    {
        public SubForm(T f) {...}
        public InitForm(T f) {...}
    }
    public partial class TestForm : BaseForm
    {
        TestSubForm sf;
        public TestForm()
        {
            ...
            sf = new TestSubForm(this);
        }
    }
    public partial class TestSubForm : BaseSubForm<TestForm>
    {
        public TestSubForm(TestForm f) : base(f)
        {
            InitializeComponent();
        }
    }
        
