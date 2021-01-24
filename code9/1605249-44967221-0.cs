    public class BaseForm : Form
    {
        public object InitialisationData { get; set; }
    }
    public partial class MagicForm : BaseForm
    {
        public string MyBindableGuy;
        public MagicForm()
        {
            InitializeComponent();
            MyBindableGuy = InitialisationData as string;
        }
    }
