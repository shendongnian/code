        //To Show Only DisplayMember in UltraCombo
		
        string[] fields = new string[]{ dt.Columns[0].ToString() };
       
        ugReqLine.DisplayMember = dt.Columns[0].ToString();
        ugReqLine.DataSource = dt;
        ugReqLine.ValueMember = dt.Columns[1].ToString();
           
        ugReqLine.SetColumnFilter(fields);   
    }
