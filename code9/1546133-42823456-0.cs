            BindingSource bs = new BindingSource();
    
            private DataTable GetDataTable()
            {
                dt.Rows.Add(r.NextDouble().ToString(), r.Next());
    
                return dt;
            }
            private void formList_Load(object sender, EventArgs e)
            {
                DataTable _dt = GetDataTable();
    
                bs.DataSource = _dt;
                gridControl1.DataSource = bs;
    
                timer1.Interval = 5000;
                timer1.Start();
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                DataTable _dt = GetDataTable();
    
                bs.DataSource = _dt;
                gridControl1.DataSource = bs;
            }
