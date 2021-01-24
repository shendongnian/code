    public class MainViewModel : INotifyPropertyChanged {
    public MainViewModel() {
      FEmployees = new ObservableCollection<Employee>();
      FEmployees.Add(new Employee {ID = 1,Name="Jordy van Eijk"});
      FEmployees.Add(new Employee {ID = 2,Name="John Doe"});
      FEmployees.Add(new Employee {ID = 3,Name="Jane Doe"});
    }
    private ObservableCollection<Employee> FEmployees;
    public ObservableCollection<Employee> Employees {
      get { return FEmployees; }
      set {
        FEmployees = value;
        OnPropertyChanged(nameof(Employees));
      }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string APropertyName = null) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(APropertyName));
    }
    }
    public class Employee {
       public int ID { get; set; }
       public string Name { get; set; }
    }
