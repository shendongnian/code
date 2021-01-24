    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("item 1");
            comboBox1.Items.Add("item 2");
            comboBox1.Items.Add("item 3");
        }
        private Control myControl;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((ComboBox)sender).SelectedItem.ToString())
            {
                case "item 1":
                    //your loading logic here
                    myControl = new UserControl();
                    myControl.Controls.Add(new TextBox());
                    break;
                case "item 2":
                    //your loading logic here
                    myControl = new UserControl();
                    myControl.Controls.Add(new Button());
                    break;
                case "item 3":
                    //your loading logic here
                    myControl = new UserControl();
                    myControl.Controls.Add(new ComboBox());
                    break;
                default:
                    myControl = null;
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(myControl);
        }
    }
