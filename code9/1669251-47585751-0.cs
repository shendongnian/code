    public class Stuff
    {
        public string Price { get; set; }
    }
    public class myCustomClass
    {
        public List<Stuff> myCollection { get; set; }
    }
    public partial class MainWindow : Window
    {
        public myCustomClass myCustomInstance = new myCustomClass();
        public MainWindow()
        {
            InitializeComponent();
            myCustomInstance.myCollection = new List<Stuff>();
            myCustomInstance.myCollection.Add(new Stuff() { Price = "1200$" });
            myCustomInstance.myCollection.Add(new Stuff() { Price = "5.5$" });
            this.DataContext = myCustomInstance;
        }
    }
