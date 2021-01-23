    public class Family : BindableBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
	//change the type here:
        private IList _selectedMembers;
        public IList SelectedMembers
        {
            get { return _selectedMembers; }
            set { _selectedMembers = value; OnPropertyChanged("SelectedMembers"); }
        }
        public override string ToString()
        {
            return Name;
        }
    }
