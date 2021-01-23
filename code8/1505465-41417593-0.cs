    public void FillDataGridView()
    {
        Cashier_NewMember F_Cashier_NewMember = new Cashier_NewMember();
        if (sqlCon.State == ConnectionState.Closed)
            sqlCon.Open();
			SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
        SqlDataAdapter sqlDa = new SqlDataAdapter("ViewOrSearchMembership",sqlcmd); 
        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        sqlDa.SelectCommand.Parameters.AddWithValue("@Member_ID", F_Cashier_NewMember.txtMemberID.Text); 
        DataTable dtbl = new DataTable();
        sqlDa.Fill(dtbl);
        dgvMembershipDetails.DataSource = dtbl;
        sqlCon.Close();
    }
