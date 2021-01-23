    public class DataItem:INotifyPropertyChanged
    {
        public DataItem(int v1,int v2,int v3)
        {
            val1 = v1;
            val2 = v2;
            val3 = v3;
            total = v1 + v2 + v3;
        }
        private int _val1;
        public int val1
        {
            get { return _val1; }
            set { _val1 = value; InvokePropertyChanged(new PropertyChangedEventArgs("val1"));}
        }
        private int _val2;
        public int val2
        {
            get { return _val2; }
            set { _val2 = value; InvokePropertyChanged(new PropertyChangedEventArgs("val2")); }
        }
        private int _val3;
        public int val3
        {
            get { return _val3; }
            set { _val3 = value; InvokePropertyChanged(new PropertyChangedEventArgs("val3")); }
        }
        private int _total;
        public int total
        {
            get { return _total; }
            set { _total = value; InvokePropertyChanged(new PropertyChangedEventArgs("total")); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
    }
