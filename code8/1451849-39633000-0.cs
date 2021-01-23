    public void CreateExcelFile()
    {
        //Get the data from database into datatable
        string cmdQry = "dbo.GET_Report";
        SqlCommand cmd = new SqlCommand(cmdQry);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@bySource", SqlDbType.VarChar).Value = "CLIENT".ToUpper();
        DataTable dtExcel = GetData(cmd);
    
        //Clears all content output from the buffer stream.  
        Response.ClearContent();
        Response.Clear();
        //Adds HTTP header to the output stream  
        Response.AddHeader("content-disposition", string.Format("attachment; filename=try.xls"));
    
        // Gets or sets the HTTP MIME type of the output stream  
        Response.ContentType = "application/vnd.ms-excel";
        string space = "";
    
        foreach (DataColumn dcolumn in dtExcel.Columns)
        {
            Response.Write(space + dcolumn.ColumnName);
            space = "\t";
        }
        Response.Write("\n");
        int countcolumn;
        foreach (DataRow dr in dtExcel.Rows)
        {
            space = "";
            for (countcolumn = 0; countcolumn < dtExcel.Columns.Count; countcolumn++)
            {
                Response.Write(space + dr[countcolumn].ToString());
                space = "\t";
            }
            Response.Write("\n");
        }
        Response.Flush();
        Response.End();
    }
    private DataTable GetData(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(Bussiness.GetConnectionString("Default"));
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
    
            try
            {
                con.Open();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                da.Dispose();
                con.Dispose();
            }
        }
