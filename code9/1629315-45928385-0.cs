    while (sqlReader.Read())
        comboBox_select_Item.Items.Add(new {
             MedName = sqlReader["MedName"].ToString(),
             MedID = sqlReader["MedID"].ToString() 
        });
