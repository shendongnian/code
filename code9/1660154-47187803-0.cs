            public Form1()
        {
            InitializeComponent();
            dgv.Columns.Add(new DataGridViewTextBoxColumn());
            dgv.Columns.Add(new DataGridViewTextBoxColumn());
            dgv.Rows.Add("key1", "value1");
            dgv.Rows.Add("key2", "value2");
            dgv.Rows.Add("key3", "value3");
            Debug.Print("original");
            dispHash();
            /*sorting*/
            dgv.Sort(dgv.Columns[1], ListSortDirection.Descending);
            Debug.Print("sorted");
            dispHash();
            /*edit*/
            dgv[1, 2].Value = "changed";
            Debug.Print("edited");
            dispHash();
            /*deleted*/
            dgv.Rows.Remove(dgv.Rows[1]);
            Debug.Print("removed");
            dispHash();
            /*add*/
            dgv.Rows.Add("key4", "value4");
            Debug.Print("add");
            dispHash();
        }
        private void dispHash()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                Debug.Print(row.Cells[0].Value + ":" + row.GetHashCode());
            }
        }
