     public Form1()
        {
            InitializeComponent();
            button1.Visible = false;
        }
        public void AfterLoginMethod()
        {
            if (userName!=null)//You can use another control like userId > 0 ...
                button1.Visible = true;
        }
