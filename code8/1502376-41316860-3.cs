	public class EmployeeVM : INotifyPropertyChanged
	{
	    SDBContext db = new SDBContext();
	    private List<Employee> _employees;
	    public List<Employee> Employees
	    {
	        get { return _employees; }
	        set
	        {
	            if (Equals(value, _employees)) return;
	            _employees = value;
	            OnPropertyChanged("Employees");
	        }
	    }
	    public EmployeeVM()
	    {
	        this.Employees = db.Employees.ToList();
	    }
	    public event PropertyChangedEventHandler PropertyChanged;
	    [NotifyPropertyChangedInvocator]
	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	    {
	        var handler = PropertyChanged;
	        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
	    }
	}
