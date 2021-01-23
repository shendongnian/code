        public int id;
        public int intID;
        public string stringID;
        bool res;
        public AddStudentDialog()
        {
            InitializeComponent();
        }
        
        public void IntToString()
        {
            stringID = textBox1.Text;
            res = int.TryParse(stringID, out id);
            if (res == true)
                intID = id;
        }
        public int tbox1
        {
            get
            {
                return intID;
            }
        }
