    public class BaseSubForm<T> : Form where T : BaseForm
    {
        public SubForm() {...}
        public InitForm(T f) {...}
    }
    public partial class TestForm : BaseForm
    {
        TestSubForm sf;
        public TestForm()
        {
            ...
            sf = new TestSubForm();
        }
    }
    public partial class TestSubForm : BaseSubForm<TestForm>
    {
        public TestSubForm(TestForm f)
        {
            InitializeComponent();
        }
    }
