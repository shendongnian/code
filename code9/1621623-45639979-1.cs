    private struct GIS
    {
        public int AccountNo;
        public string AccountName;
    }
    private void Test()
    {
    
        try
        {
            string xlConnStr = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Users\jonat\Documents\TestCSharp.xlsx;Extended Properties='Excel 8.0;HDR=Yes;';";
            var xlConn = new OleDbConnection(xlConnStr);
    
            var da = new OleDbDataAdapter("SELECT * FROM [mer_SVC$]", xlConn);
            var xlDT = new DataTable();
            da.Fill(xlDT);
    
            List<GIS> xl = xlDT.AsEnumerable().Select(g => new GIS()
            {
                AccountNo = (int)g.Field<double>("Account No"),
                AccountName = g.Field<string>("Account Name")
            }).ToList();
    
            string acConnStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\Users\jonat\Documents\PricingTools.accdb;Jet OLEDB:Engine Type=5;Persist Security Info=False;";
    
            var acConn = new OleDbConnection(acConnStr);
            da = new OleDbDataAdapter("SELECT * FROM GIS", acConn);
            var acDT = new DataTable();
            da.Fill(acDT);
    
            List<GIS> ac = acDT.AsEnumerable().Select(g => new GIS()
            {
                AccountNo = g.Field<int>("Account No"),
                AccountName = g.Field<string>("Account Name")
            }).ToList();
    
            var missing = xl.Where(x => !ac.Any(a => a.AccountNo == x.AccountNo));
            DataTable dt = acDT.Clone();
            foreach (var m in missing)
            {
                var n = dt.NewRow();
                n["Account No"] = m.AccountNo;
                n["Account Name"] = m.AccountName;
                dt.Rows.Add(n);
            }
    
            dataGridView1.DataSource = dt;
    
        }
        catch (Exception ex)
        {
            MessageBox.Show("Exception thrown; " + ex.Message);
        }
    }
