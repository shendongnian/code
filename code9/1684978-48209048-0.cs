      public Form1()
        {
            InitializeComponent();
            List<string> filters = new List<string> { "T05A1.1", "C16D6.2", "F41E7.3" };
            checkedListBox1.Items.Clear();
            foreach (string filter in filters)
            {
                checkedListBox1.Items.Add(filter);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> selectedFilter = new List<string>();
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                selectedFilter.Add("'" + checkedListBox1.CheckedItems[i].ToString() + "'");
            }
            string query = "Select * from Table1 where elegansgeneID in(" + string.Join(",", selectedFilter) + ")";
        }
