      public class obj
        {
            public string Left { get; set; }
            public string Right { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            List<obj> objects = new List<obj>();
            for (int i = 0; i < 10; i++)
            {
                var left = "aaaaa";
                var right = "bbbbb";
                objects.Add(new obj() { Left = left, Right = right }); 
            }
            ic.ItemsSource = objects;
             
        }
