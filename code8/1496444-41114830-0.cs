    public partial class Form1 : Form
    {
        List<Button> buttonList = new List<Button>();
        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            Button btn = new Button();
            btn.Location = new Point(20 , i* 30);
            buttonList.Add(btn); // add instance to list
            this.Controls.Add(btn); // add the same instance to the form
            for (int j = 0; j < buttonList.Count; ++j)
            {
                //  do whatever you want here
                buttonList[j].Text = j.ToString();
            }
            
        }
    }
