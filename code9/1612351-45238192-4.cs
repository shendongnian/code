    //CTOR
    public EmployeesView() {
        this.InitializeComponents();
        this.Employees = new ObservableCollection<EmployeeViewModel>();
        //Bind the view so that 
        this.DataContext = this;
    }
    public ObservableCollection<EmployeeViewModel> Employees { get; private set; }
    private void btnFindAllEmployees_Click(object sender, RoutedEventArgs e) {
        //...code removed for brevity
    }
