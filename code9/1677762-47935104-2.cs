    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MVObjectManager Manager=new MVObjectManager();
            Manager.ListObjects.Add(new MVDragableObject());
            Manager.ListObjects.Add(new MVDragableObject());
            Manager.ListObjects.Add(new MVDragableObject());
            MainView.DataContext  = Manager;
        }
    }
