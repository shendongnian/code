    using (SqlCommand cmd = new SqlCommand("spR_CSVDownload", con))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Id", downloadItem);
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        Response.Clear();
        Response.ContentType = "text/csv";
        Response.AddHeader("Content-Disposition", "attachment;filename=download.csv");
        while (reader.Read())
        {
            Response.Write("\"" + reader["SchemeCode"].ToString() + "\",");
            Response.Write("\"" + reader["SchemeCodeDescr"].ToString() + "\",");
            Response.Write("\"" + reader["OwningCompany"].ToString() + "\",");
            Response.Write("\"" + reader["PrimaryManagingCompany"].ToString() + "\",");
            Response.Write("\"" + reader["ManagingCompany"].ToString() + "\",");
            Response.Write("\"" + reader["RentAccountManagment"].ToString() + "\",");
            Response.Write(Environment.NewLine);
        }
        Response.End(); 
    }
