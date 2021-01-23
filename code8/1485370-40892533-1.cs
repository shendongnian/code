    // Update the Control file 
    SqlConnection UpdRejConnection = new SqlConnection("Data Source=GBAPTCCSR01;Initial Catalog=CInTracDB;Integrated Security=True");
    SqlCommand Updcmd = new SqlCommand();
    SqlDataReader Updreader;
    Updcmd.Parameters.AddWithValue("@CAssetID", Session["ChangeRecord"]);
    Updcmd.Parameters.AddWithValue("@Reason", ReasonTextBox.Text.ToString());
    Updcmd.Parameters.AddWithValue("@Rejby", RejByTextBox.Text.ToString());
    Updcmd.Parameters.AddWithValue("@Source", SourceTextBox.Text.ToString());
    Updcmd.Parameters.AddWithValue("@RejDT", RejDTTextBox.Text.ToString());
    Updcmd.CommandText = "usp_UpdRejCtrl";
    Updcmd.CommandType = CommandType.StoredProcedure;
    Updcmd.Connection = UpdRejConnection;
    UpdRejConnection.Open();
    Updreader = Updcmd.ExecuteReader();
    UpdRejConnection.Close();
