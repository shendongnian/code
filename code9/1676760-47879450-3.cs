    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Test> oc { get; set;}
        public MainPage()
        {
            this.InitializeComponent();
            oc = new ObservableCollection<Test>();
            oc.CollectionChanged += Oc_CollectionChanged;
            for (int i=0;i<10;i++)
            {
                oc.Add(new Test() {SerialNumber=i,source=new BitmapImage(new Uri("ms-appx:///Assets/test.png")) });
            }
            this.DataContext = this;
        }
        private void Oc_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                for (int i =e.OldStartingIndex; i<oc.Count;i++)
                {
                    oc[i].SerialNumber = i;
                }
            }
        }
    }
    public class Test:INotifyPropertyChanged
    {
        private int _SerialNumber;
        public int SerialNumber
        {
            get { return _SerialNumber; }
            set
            {
                _SerialNumber = value;
                RaisePropertyChanged("SerialNumber");
            }
        }
        private BitmapImage _source;
        public BitmapImage source
        {
            get { return _source; }
            set
            {
                _source = value;
                RaisePropertyChanged("source");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
