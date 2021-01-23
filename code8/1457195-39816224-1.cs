            OleDbConnection oledbCnn=null;
            OleDbDataAdapter oledbAdapter = null;
            DataSet ds=null;
            string connetionString = WebConfigurationManager.ConnectionStrings["SQLServerConnectionString"].ConnectionString;
            string sql = "SELECT * FROM Profile ORDER BY FullName ASC";
            try
            {
                oledbCnn = new OleDbConnection(connetionString);
                oledbCnn.Open();
                oledbAdapter = new OleDbDataAdapter(sql, oledbCnn);
                ds = new DataSet();
                oledbAdapter.Fill(ds, "Profile");
                foreach (DataRow row in ds.Tables["Profile"].Rows)
                {
                    Response.Write("Employee: " + " " + row["FullName"].ToString() + " " + row["Academy"].ToString() + "<p>");
                }
                oledbCnn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Can not open connection ! ");
            }
            finally
            {
                if (oledbCnn != null) oledbCnn.Dispose();
                if (oledbAdapter != null) oledbAdapter.Dispose();
                if (ds != null) ds.Dispose();
            }
