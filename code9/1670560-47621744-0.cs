        private List<string> uitkomsten = new List<string>();
        private BindingSource bs = new BindingSource();
        public MainForm()
        {
            InitializeComponent();
            bs.DataSource = uitkomsten;
            lb_list.DataSource = bs;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ......
            uitkomsten.Add(Convert.ToString(nieuwbmi));
            bs.ResetBindings(false);
        }
