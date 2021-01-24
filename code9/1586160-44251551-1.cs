    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Owner != null && this.Owner is Main_Program)
            {
                Main_Program mp = (Main_Program)this.Owner;
                mp.orderALERT.Enabled = true;
                mp.orderALERT.Visible = true;
                mp.orderALERT.Refresh();
            }
        }
    }
