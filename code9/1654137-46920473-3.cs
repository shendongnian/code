        DataTable ta = new DataTable();
        ta.Columns.Add("Id");
        ta.Columns.Add("Name");
        ta.Columns.Add("Address");
        ta.Columns.Add("StatusId");
        ta.Columns.Add("SubStatusId");
        ta.Columns.Add("Dubs");
        DataTable tb = new DataTable();
        tb.Columns.Add("Id");
        tb.Columns.Add("StatusId");
        tb.Columns.Add("SubStatusId");
        tb.Columns.Add("Status");
        tb.Columns.Add("SubStatus");
        tb.Columns.Add("Type");
        string[] tas =
        {
             "1,ABC,XYZ,1,39,10"
            ,"2,PQR,XYZ,1,39,20"
            ,"3,ME,WWW,2,39,0"
            ,"4,YOU,XYZ,1,22,2"
            ,"5,HE,XYZ,2,22,5"
            ,"6,SHE,WWW,2,41,0"
        };
        string[] tbs =
        {
            "1,1,39,Dispense,Ready,1"
           ,"2,2,39,Fill,Ready,2"
           ,"3,2,22,Ship,Active,0"
           ,"4,2,41,Del,Pending,0"
           ,"5,1,22,Verify,Pending,0"
        };
        foreach (string t in tas)
        {
            string[] x = t.Split(',');
            DataRow row = ta.NewRow();
            for (int i = 0; i < x.Length; i++) row[i] = x[i];
            ta.Rows.Add(row);
        }
        foreach (string t in tbs)
        {
            string[] x = t.Split(',');
            DataRow row = tb.NewRow();
            for (int i = 0; i < x.Length; i++) row[i] = x[i];
            tb.Rows.Add(row);
        }
