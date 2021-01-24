    public void DeleteAppImage()
    {
        try
        {
            using (var del = new FbConnection(ClsConnectionImages.FirebirdSQL))
            using(var fbcmd = new FbCommand("APP_DELETE", del))
            {
                fbcmd.Parameters.Add("@WORKXP_PK", FbDbType.Integer).Value = ClsEmployee.UpdateHandler2;
                fbcmd.CommandType = CommandType.StoredProcedure;
                del.Open();
                fbcmd.ExecuteNonQuery();
             }
        }
        catch (Exception errorcode)
        {
            XtraMessageBox.Show(String.Format("Error in connection: {0} Process failed.", errorcode.Message), @"Server Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
