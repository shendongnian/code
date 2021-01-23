    public Vägval(string name, string gender, int gold)
        {
            InitializeComponent();
            ChoosePicture(gender);
            //assigns all the properties
            this.Namn = name;
            this.Gender = gender;
            this.Gold = gold;
           
            //Set GUI 
            tname.Text = name;
            tMynt.Text = gold.ToString();
            tLife.Text = 5.ToString();
        }
