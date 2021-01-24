        public partial class Form1 : Form
    {
        List<BillItem> _Items = new List<BillItem>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn clmItemName = new DataColumn("clmItemName", typeof(string));
            dt.Columns.Add(clmItemName);
            dt.Rows.Add("Parle-G");
            dt.Rows.Add("Kardjack");
            dgv_ItemNamePOS.DataSource = dt;
            // to simulate items' details in database
            _Items.Add(new BillItem() { No = 1, ItemName = "Parle-G", Code = "P-G", MRP = "***" });
            _Items.Add(new BillItem() { No = 1, ItemName = "Kardjack", Code = "K", MRP = "@@@" });
        }
        class BillItem
        {
            public int No { get; set; }
            public string ItemName { get; set; }
            public string Code { get; set; }
            public string MRP { get; set; }
        }
        private void dgv_ItemNamePOS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string a = dgv_ItemNamePOS.CurrentRow.Cells[0].Value.ToString();
            dgv_POS.Rows[0].Cells[1].Value = a.ToString();
           BillItem billItem = _Items.First(item => item.ItemName == a);
            dgv_POS.Rows[0].Cells[0].Value = billItem.No.ToString();
            dgv_POS.Rows[0].Cells[2].Value = billItem.Code.ToString();
            dgv_POS.Rows[0].Cells[3].Value = billItem.MRP;
        }
    }
    
