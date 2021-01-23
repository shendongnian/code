    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filename + ";" + "Extended  Properties='Excel 12.0;HDR=YES;IMEX=1;';";
   
    string query = string.Format("SELECT * FROM [{0}$]", tablename);
            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString))
            {
                DataSet jobDataSet = new DataSet();
                dataAdapter.Fill(jobDataSet, "jobInfo");
                DataTable jobDataTable = jobDataSet.Tables["jobInfo"];
            }
