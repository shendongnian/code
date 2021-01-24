     protected void Gridview1_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
    
    SqlConnection con = new SqlConnection(constr);
    SqlCommand cmd = new SqlCommand();
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.CommandText = "update_department";
    cmd.Parameters.Add("@DeptId", SqlDbType.Int).Value = Convert.ToInt32(e.Keys["DeptId"]);
    cmd.Parameters.Add("@DeptName", SqlDbType.NVarChar).Value = e.NewValues["DeptName"];
    
    cmd.Connection = con;
    
    try
    {
        con.Open();
        cmd.ExecuteNonQuery();
        e.Cancel = true;
        GridView1.CancelEdit();
        BindDeapartment();
    
    
    }
    
    catch (Exception ex)
    {
        throw ex;
    }
    
    finally
    {
        con.Close();
        con.Dispose();
    }
    
    }
