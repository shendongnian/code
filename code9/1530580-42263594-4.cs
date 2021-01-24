        public MainWindow()
        {
            InitializeComponent();
            ModelView mv = new ModelView();
            mv.Models.Add(new Model() { Name = "a", Desc = "aaa" });
            mv.Models.Add(new Model() { Name = "b" , Desc = "bbb"});
            mv.Models.Add(new Model() { Name = "c", Desc = "cccc" });
            this.DataContext = mv; 
        }
