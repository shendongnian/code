    public partial class Form1 : Form
    {
        [Dependency]
        public Invoice { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
    }
