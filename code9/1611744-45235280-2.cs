    // Put this to the event or sub where you want to query for data
     Private DataGridView dgv;
     Private DataView _tblView;
     private void Form1_Load(object sender, EventArgs e) {
            DataTable tbl = myModule.GetDataTableWithRows();
            //  Imagine we have Columns "CutomerID", "CustomerLastName", "CustomerPriority"
            _tblView = new DataView(tbl);
            _tblView.RowFilter = "";
            dgv.DataSource = _tblView;
        }
