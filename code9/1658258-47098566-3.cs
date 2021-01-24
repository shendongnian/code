     class EmployeeViewModel
    {
        private readonly Action<object> navigate;
        public ICommand Navigate { get; set; }
        public EmployeeViewModel(Action<object> navigate)
        {
            Navigate = new BaseCommand(OnNavigate);
            this.navigate = navigate;
        }
        private void OnNavigate(object obj)
        {
            navigate.Invoke("Dept");
        }
    }
