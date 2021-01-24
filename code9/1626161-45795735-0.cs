        public void Main()
        {
         OleDbDataAdapter A = new OleDbDataAdapter();
         System.Data.DataTable dt = new System.Data.DataTable();
         A.Fill(dt, Dts.Variables["User::Hosps"].Value);  List<string> myValues = new list<string>();
        foreach (DataRow row in dt.Rows)
        {
             myValues.Add(row[0].ToString());
        }
