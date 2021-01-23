    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SingletonA.GetInstance.MyEvent += UpdateListView;
        }
    
        private void UpdateListView(object sender, EventArgs e)
        {
            // Update your listview
        }
    }
    
    //lazy initialization of singleton - not thread safe see http://www.dotnettricks.com/learn/designpatterns/singleton-design-pattern-dotnet for other thread safe version
    public class SingletonA
    {
        private static SingletonA instance = null;
        private SingletonA() { }
    
        public event EventHandler<EventArgs> MyEvent;
    
        void TellFormToUpdateListView()
        {
            MyEvent?.Invoke(typeof(SingletonA), EventArgs.Empty);
        }
    
        public static SingletonA GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new SingletonA();
    
                return instance;
            }
        }
    }
