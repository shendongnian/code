    public void FillDataGridView(){
        Cashier_NewMember F_Cashier_NewMember = new Cashier_NewMember();
        if (sqlCon.State == ConnectionState.Closed)
            sqlCon.Open();
        SqlDataAdapter sqlDa = new SqlDataAdapter("ViewOrSearchMembership", sqlCon);
        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        sqlDa.SelectCommand.Parameters.AddWithValue("@Member_ID", F_Cashier_NewMember.txtMemberID.Text); 
        DataTable dtbl = new DataTable();
        sqlDa.Fill(dtbl);
        dgvMembershipDetails.DataSource =null;
        dgvMembershipDetails.DataSource = dtbl;
        sqlCon.Close();
    }
        
