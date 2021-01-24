    public partial class Form1 : Form
    {
        int counter;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // increment counter for whits groupbox you want to show
            counter++;
            switch (counter)
            {
                case 1:
                    groupBox1.Visible = true;
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                    groupBox4.Visible = false;
                    break;
                case 2:
                    groupBox1.Visible = false;
                    groupBox2.Visible = true;
                    groupBox3.Visible = false;
                    groupBox4.Visible = false;
                    break;                   
                case 3:
                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    groupBox3.Visible = true;
                    groupBox4.Visible = false;
                    break;
                case 4:
                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                    groupBox4.Visible = true;
                    // set to 0 if counter is 4 so groupbox one will be the next grupbox that will be set to visible
                    counter = 0;
                    break;
            }
        }
    }
