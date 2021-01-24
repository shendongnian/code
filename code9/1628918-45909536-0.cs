    namespace GymCheckList
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private List<string> data1;
            public List<string> Data1
            {
                get
                {
                    if(data! == null) data! = new List<string>();
                    return data1;
                }
            }
