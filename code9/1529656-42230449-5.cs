    class MenuViewModel
    {
        public ICommand EmpCommand { get; set; }
        public ICommand DeptCommand { get; set; }
        private readonly NavigationViewModel _navigationViewModel;
        public MenuViewModel(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;
            EmpCommand = new BaseCommand(OpenEmp);
            DeptCommand = new BaseCommand(OpenDept);
        }
        private void OpenEmp(object obj)
        {
            _navigationViewModel.SelectedViewModel = new EmployeeViewModel();
        }
        private void OpenDept(object obj)
        {
            _navigationViewModel.SelectedViewModel = new DepartmentViewModel();
        }
    }
