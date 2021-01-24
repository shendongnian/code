        public MainWindow()
        {
            InitializeComponent();
            Foobar.DoParentThing = myPublicMethod;
        }
        public void myPublicMethod()
        {
            //  do stuff
        }
