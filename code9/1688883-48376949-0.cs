    foreach (var _PO_No in list)
    {
        ShippingData_Export(_PO_No, ds);
    }
    
    private void ShippingData_Export(string X_PO_NO, DataSet ds)
    {
        var sqlConn = new SqlConnection(strConStr);
        try
        {
            sqlConn.Open();
            var cmd = new SqlCommand("proc_TBL_PO_M_ShippingExcel", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@X_PO_NO", X_PO_NO);
            var da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlConn.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        return ds;
    }
