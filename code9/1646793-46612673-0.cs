    <Grid >
        <StackPanel>
            <StackPanel Orientation="Horizontal">
                <TextBlock Text="Filter"/>
                <TextBox Text="{Binding TextValue, Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" Width="200"/>
            </StackPanel>
            <ListBox ItemsSource="{Binding EmpView}" DisplayMemberPath="Name"/>
        </StackPanel>
      
    </Grid>
    class ViewModel : INotifyPropertyChanged
    {
        private string myVar;
        public string TextValue
        {
            get { return myVar; }
            set { myVar = value;
                OnPropertyChanged("TextValue"); EmpView.Refresh();}
        }
        public ICollectionView EmpView { get; set; }
        public List<Employee> Employees { get; set; }
        public ViewModel()
        {
            Employees = new List<Employee>()
            {
                new Employee() {Name = "Test1"},
                new Employee() {Name = "Version2"},
                new Employee() {Name = "Test2"},
                new Employee() {Name = "Version4"},
                new Employee() {Name = "Version5"}
            };
            EmpView = CollectionViewSource.GetDefaultView(Employees);
            EmpView.Filter = Filter;
        }
        private bool Filter(object emp)
        {
            if (string.IsNullOrWhiteSpace(TextValue))
            {
                return true;
            }
            var emp1 = emp as Employee;
            return TextValue != null && (emp1 != null && emp1.Name.Contains(TextValue));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    class Employee
    {
        public string Name { get; set; }
    }
