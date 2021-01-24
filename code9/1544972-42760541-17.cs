    public class MyUserControl
    {
        public MyUserControl()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        public List<MyItem> MySrcList = new List<MyItem>();
    }
