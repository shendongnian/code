    public class RollsViewModel : ViewModelBase
    {
        public ObservableCollection<Item> emp
        {
            get;
            set;
        }
        public bool ContainsItems
        {
            get { return _containsItems; }
            set { _containsItems = value; RaisePropertyChanged(); }
        }
        private bool _containsItems;
        public RollsViewModel()
        {
            emp = new ObservableCollection<Item>();
        }
        public ICommand BtnClick
        {
            get
            {               
                if (_btnClick == null)
                {
                    _btnClick = new RelayCommand(() =>
                    {
                        // Dummy action, replace with call to model
                        emp.Add(new Item() { Name = "A roll", RollNo = emp.Count });
                        ContainsItems = emp.Count > 0;
                    });
                }
                return _btnClick;
            }
        }
        private RelayCommand _btnClick;       
    }
    public class Item : ViewModelBase
    {
        public int RollNo
        {
            get { return _rollNo; }
            set { _rollNo = value; RaisePropertyChanged();  }
        }
        private int _rollNo;
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(); }
        }
        private string _name;
    }
