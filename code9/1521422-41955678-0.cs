      public partial class Form1 : Form
    {
       
        private Form2 f2;
        private obj returnedData;
        public Form1()
        {
            InitializeComponent();
 
          
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
             f2 = new Form2();
            f2.FormClosing += F_FormClosing;
            f2.Show();
        }
        private void F_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.returnedData = f2.GetData();  //clicked data is returned to your main form, do what you want with it
        }
    }
    public partial class Form2 : Form
    {
        private List<obj> list;
        private obj selectedData;
        public Form2()
        {
            InitializeComponent();
            data.CellDoubleClick += DataGridView1_CellDoubleClick;
            list = new List<obj>();
            data.AutoGenerateColumns = true;
            list.Add(new obj() { a = "abc1", b = "abc2" });
            list.Add(new obj() { a = "cda1", b = "cda2" });
            data.DataSource = list;
        }
        internal obj GetData()
        {
            return selectedData;
        }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedData = list.ElementAt(e.RowIndex);
            this.Close();
        }
    }
    internal class obj
    {
        [DisplayName("aaa")]
        public string a { get; set; }
        [DisplayName("bbb")]
        public string b { get; set; }
    }
