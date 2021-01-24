    public partial class DialogWindow : Window, IViewFor<DialogWindowViewModel>
    {
        public DialogWindow()
        {
            InitializeComponent();
            this.ViewModel = new DialogWindowViewModel();
            this.DataContext = this.ViewModel;
            this.ViewModel
                .WhenAnyValue(x => x.DialogResult)
                .Where(x => null != x)
                .Subscribe(val =>
                {
                    this.DialogResult = val;
                    this.Close();
                });
        }
        public DialogWindowViewModel ViewModel { get; set; }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (DialogWindowViewModel)value;
        }
    }
