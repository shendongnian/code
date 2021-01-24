    public class StaffMember : NotifyObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        private string _position;
        public string Position
        {
            get { return _position; }
            set { _position = value; OnPropertyChanged("Position"); }
        }
    }
    public class Person : NotifyObject
    {
        private string _staffMember;
        public string StaffMember
        {
            get { return _staffMember; }
            set { _staffMember = value; OnPropertyChanged("StaffMember"); }
        }
        public double Age { get; set; }
    }
