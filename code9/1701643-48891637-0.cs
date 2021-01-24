    public class SomeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<IGrade> grades;
        
        public SomeViewModel()
        {
            Grades = new ObservableCollection<IGrade>()
            {
                new Grade(1, "BelowStandards"), 
                new Grade(2, "MeetsStandards"), 
                new Grade(3, "AboveStandards") 
            };
        }
        
        // Add new grade here.
        public void AddGrade(string name)
        {
            if (Grades == null)
                throw new ArgumentNullException("can't be null here");
                
            Grades.Add(new Grade(Greads.Count + 1, name));
        }
    
        public ObservableCollection<IGrade> Grades 
        {
            get { return grades; }
            set { SetField(ref grades, value, "Grades"); }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
    
    public interface IGrade : INotifyPropertyChanged
    {
        int Id { get; }
        string Name { get; }
    }
    
    public class Grade : IGrade 
    {
        public Grade(int id, string name)
        {
            Id = id; 
            Name = name;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        private int id;
        public int Id
        {
            get { return id; }
            set { SetField(ref id, value, "Id"); }
        }
        
        private string name;
        public string Name
        {
            get { return name; }
            set { SetField(ref name, value, "Name"); }
        }
    }
    
