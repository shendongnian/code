    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        private bool _isDirty;
        public bool IsDirty
        {
            get
            {
                return _isDirty;
            }
            set
            {
                _isDirty = value;
                OnChanged(nameof(IsDirty));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MyBindingGroup.BeginEdit();        // Not really needed?
            gridMain.KeyUp += GridMain_KeyUp;
        }
        private void GridMain_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (this.MyBindingGroup.IsDirty)
            {
                IsDirty = true;
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (this.BindingGroup.CommitEdit())
            {
                EmployeeViewModel vm = (EmployeeViewModel)this.DataContext;
                vm.Save();
                IsDirty = false;
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.BindingGroup.CancelEdit();
            IsDirty = false;
        }
    }
