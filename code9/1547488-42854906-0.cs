    public interface IBlah
    {
        string ExplicitMember { get; set; }
        string Member { get; set; }
    }
    public partial class MainWindow : IBlah
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        string IBlah.ExplicitMember { get; set; } = "Hidden";
        public string Member { get; set; } = "Visible";
    }
