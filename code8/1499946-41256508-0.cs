        using System.Data.SqlServerCe;
        
        string sqlConnection = "Data Source";
        SqlCeConnection conn = new SqlCeConnection(sqlConnection);
        //Get bind from database.
        string qryGetCategory = "Query to get data for combo box";
        SqlCeCommand cmdCat = new SqlCeCommand(qryGetCategory, conn);
        SqlCeDataAdapter daCat = new SqlCeDataAdapter(qryGetCategory, conn);
        DataTable dtCat = new DataTable();
        daCat.Fill(dtCat);
    
        //Combobox column.
        DataGridViewComboBoxColumn ComboBoxCol = new DataGridViewComboBoxColumn();
        ComboBoxCol.DataSource = dtCat;
        ComboBoxCol.Name = "Column name";
        ComboBoxCol.ValueMember = "Value of member";
        ComboBoxCol.DisplayMember = "Member to be show";
        ComboBoxCol.DropDownStyle = ComboBoxStyle.DropDown;
        datagridview.Columns.Add(ComboBoxCol);
