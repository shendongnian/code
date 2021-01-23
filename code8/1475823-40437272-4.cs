    public delegate void ButtonClick(object sender, EventArgs e);
    public partial class DataBox : UserControl
    {
        public DataRow row  { get; set; }
      
        public ButtonClick ButtonClick { private get; set; }
        public DataBox()
        {
            InitializeComponent();
        }
        public DataBox(DataRow row)
        {
            InitializeComponent();
            loadRow(row);
            button1.GotFocus += (s, e) => { BackColor = Color.SkyBlue; };
            button1.LostFocus += (s, e) => { BackColor = Color.Azure; };
        }
        public void loadRow(DataRow row_)
        {
            if (row_ == null || row_.ItemArray.Length < 3) return;
            row = row_;
            label1.Text = row.ItemArray[0].ToString();
            label2.Text = row.ItemArray[1].ToString();
            label3.Text = row.ItemArray[2].ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ButtonClick != null) ButtonClick(sender, e);
        }
    }
