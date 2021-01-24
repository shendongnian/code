        public Form1()
        {
            InitializeComponent();
            dgv1.Columns.Add(new DataGridViewTextBoxColumn());
            dgv1.Columns.Add(new DataGridViewTextBoxColumn());
            dgv1.Columns.Add(new DataGridViewTextBoxColumn());
            dgv1.Rows.Add(1, 2, 3);
            dgv1.Rows.Add(4, 5, 6);
            dgv2.Columns.Add(new DataGridViewTextBoxColumn());
            dgv2.Columns.Add(new DataGridViewTextBoxColumn());
            dgv2.Columns.Add(new DataGridViewTextBoxColumn());
            dgv2.Rows.Add(1, 2, 3);
            dgv2.Rows.Add(4, 5, 6);
            var ar1 = string.Join(",", (from row in dgv1.Rows.OfType<DataGridViewRow>()
                                        from cell in row.Cells.OfType<DataGridViewCell>()
                                        select cell.Value));
            var ar2 = string.Join(",", (from row in dgv2.Rows.OfType<DataGridViewRow>()
                                        from cell in row.Cells.OfType<DataGridViewCell>()
                                        select cell.Value));
            Debug.Print((ar1.Equals(ar2)).ToString());
        }
