        private IDictionary<string, AClass> aList;
        private myBindingSource bs;
        
        public Form1()
            {
            InitializeComponent();
            aList = new Dictionary<string, AClass>();
       
            bs = new myBindingSource(aList);
            dgv.DataSource = bs;
            aList.Add("1", new AClass());
            aList.Add("2", new AClass { data1 = "AA", data2 = "BB" });
            bs.ResetBindings(false);
            }
