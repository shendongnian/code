    public class EmployeeViewModel : INotifyPropertyChanged
    {
      public event PropertyChangedEventHandler PropertyChanged;
    
      public string FirstName {get;set;}
      public string LastName {get;set;}
      public string FullName => $"{FirstName} {LastName}";
    }
