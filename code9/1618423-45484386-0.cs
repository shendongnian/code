    var gCon = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
    using (var nCon = new SqlConnection(gCon))
    {
        try
        {
            nCon.Open();
            String cmd = "SELECT DISTINCT Refrence_ID FROM TableA";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(cmd, nCon);
            DataTable Dt = new DataTable();
            adapter.Fill(Dt);
            
            for (int count = 0; count < Dt.Rows.Count(); count++)
            {
                string dCmd = "SELECT ID FROM TableA WHERE Reference_ID = '" + dt.Rows[count]["Refrence_ID"] + "'";
                SqlDataAdapter dSda = new SqlDataAdapter();
                dSda.SelectCommand = new SqlCommand(dCmd, nCon);
                DataTable dDt = new DataTable();
                dSda.Fill(dDt);
                for (int i = 0; i < dDt.Rows.Count; i++)
                {
                    Response.Write(dDt.Rows[i]["Distributor_ID"]);
                }
            }
        }
        catch (Exception e)
        {
            Response.Write(e.ToString());
        }
        finally { nCon.Close(); }
    }
