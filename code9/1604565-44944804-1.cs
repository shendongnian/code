        public partial class MainWindow : Window
    {
        private string fileName = "lst.txt";
        private List<string> lst;
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += (s, e) =>
              {
                  File.WriteAllLines(fileName, this.lst);
              };
        }
        //in other events, button click, initialize or change the lst
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.lst = File.ReadAllLines(fileName).ToList();
            }
            catch (Exception)
            {
              
            }
        }
        //simulate your other changes to the lst
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lst == null)
                lst = new List<string>();
            lst.Add(new Random().Next().ToString());
        }
    }
