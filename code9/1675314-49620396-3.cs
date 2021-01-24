    public partial class Form1: Form, IViewFor<MainViewModel>
    {
        public Form1()
        {
            InitializeComponent();
            // ViewModel initialization
            this.ViewModel = new MainViewModel();
            // binding creation when the form is activated
            this.WhenActivated(dispose => {
                // the command binding will be disposed when the form is deactivated, no memory leaks
                dispose(this.BindCommand(this.ViewModel, x => x.AsyncProcess, x => x.btnStart));
            });
        }
        public MainViewModel ViewModel { get;  set; }
        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = value as MainViewModel; }
        }
    }
