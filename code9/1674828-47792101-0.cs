    public class ModelExample : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string myStringValue = "";
        public string MyStringValue
        {
            get
            {
                return myStringValue;
            }
            set
            {
                myStringValue = value;
                MyBoolValue = !string.IsNullOrEmpty(myStringValue) && myStringValue.Length > 4;
            }
        }
        private bool myBoolValue;
        public bool MyBoolValue
        {
            get
            {
                return myBoolValue;
            }
            set
            {
                myBoolValue = value;
            }
        }
        public string Error
        {
            get
            {
                if (MyStringValue.Length < 5)
                {
                    return "Invalid string value";
                }
                return string.Empty;
            }
        }
        public string this[string columnName]
        {
            get
            {
                return Error;
            }
        }
    }
