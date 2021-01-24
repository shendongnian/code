    public partial class Form1: Form, IViewFor<MainViewModel>
    {
        public Form1()
        {
            InitializeComponent();
            this.ViewModel = new MainViewModel();
            this.WhenActivated(a => {
                a(this.BindCommand(this.ViewModel, x => x.AsyncProcess, x => x.btnStart));
            });
        }
        public MainViewModel ViewModel { get;  set; }
        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = value as MainViewModel; }
        }
    }
