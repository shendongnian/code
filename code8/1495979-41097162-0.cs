    public bool CheckExcel(string tableName, string localFileNamePath)
    {
        bool status=false;
        string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + localFileNamePath + ";Extended Properties='Excel 12.0;IMEX=1'";
        try
        {
            var adapter = new OleDbDataAdapter("Select * FROM [Sheet1$]", Excel07ConString);
            var ds = new DataSet();
            adapter.Fill(ds, "myTable");
            DataTable data = ds.Tables["myTable"];
            //Data table hold only first column of excel file.
            DataTable CustomDT=new DataTable();
            CustomDT.Columns.Add("FirstColumnName", typeof(string));
            foreach(DataRow row in data.Rows)
            {
                CustomDT.Rows.Add(row("Columnn name in excel").ToString());
            }
            DataGridView.DateSource=CustomDt;
            //Function to write data in database.
            string sqlConnection = "Data Source=Database path";
            SqlCeConnection conn = new SqlCeConnection(sqlConnection);
            conn.Open();
            foreach(DataRow row in data.Rows)
            {
                string qryUser = "Insert into TableName(Column) values('" + row["ColumnName"].ToString() + "')";
                var comCheck = new SqlCeCommand(qryUser, conn);
                comCheck.ExecuteScalar();
            }
            comCheck.Dispose();
            conn.Close();
        }
    }
