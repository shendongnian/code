    public partial class Form1 : Form
    {
        public Container { get; set; }
        public Form1(IUnityContainer container)
        {
            InitializeComponent();
            this.Container = container;
            var invoice = Container.Resolve<Invoice>();
        }
    }
