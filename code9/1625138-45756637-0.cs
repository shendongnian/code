    public class ViewModel
    {
        public ViewModel()
        {
            YourCommandProperty = new DelegateCommand(Check);
        }
        private string _EmpID;
        public string EmpID
        {
            get
            {
                return _EmpID;
            }
            set
            {
                if (_EmpID == value)
                {
                    return;
                }
                _EmpID = value;
            }
        }
        public ICommand YourCommandProperty { get; }
        private void Check(object o)
        {
            //look up EmpId here...
            MessageBox.Show("...");
        }
    }
