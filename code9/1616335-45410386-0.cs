    SqlConnection oConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["evaConn"].ConnectionString);
    try
    {
        oConn.Open();
        SqlCommand oCmd = new SqlCommand();
        oCmd.Connection = oConn;
        oCmd.CommandText = str;
        SqlDataReader dr = oCmd.ExecuteReader();
        lstLeft.DataTextField = "drname";
        lstLeft.DataValueField = "drid";
        lstLeft.DataSource = dr;
        lstLeft.DataBind();
        dr.Close();//Close dr here
        dr = oCmd.ExecuteReader();//fill it again here
        for (int j = 0; j < lstLeft.Items.Count; j++)
        {
            while (dr.Read())
            {
                if (dr["othermr"].ToString() == "1")
                {
                    lstLeft.Items[j].Text = lstLeft.Items[j].Text + " (Assigned to - " + dr["mrname"].ToString() + ")";
                }
            }
        }
        dr.Close();
    }
    catch (Exception)
    {
    }
    finally
    {
        oConn.Close();
        oConn.Dispose();
    }
