    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Test> oc { get; set;}
        public MainPage()
        {
            this.InitializeComponent();
            oc = new ObservableCollection<Test>();
            for (int i=0;i<10;i++)
            {
                oc.Add(new Test() {SerialNumber=i,source=new BitmapImage(new Uri("ms-appx:///Assets/test.png")) });
            }
            this.DataContext = this;
        }
    }
    public class Test
    {
        public int SerialNumber { get; set; }
        public BitmapImage source { get; set; }
    }
