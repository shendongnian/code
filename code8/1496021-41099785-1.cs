     var fileNamelist = new List<string>();
        foreach (DataGridViewRow dtrow2 in frm.dataGridView2.Rows)
    {
        con = new SqlConnection(cs.DBConn);
        con.Open();
        //if null or empty set it to a default value. here i set it to "".
        var fileName = string.IsNullOrEmpty(dtrow2.Cells[2].Value.ToString())
                                   ? ""
                                   : dtrow2.Cells[2].Value.ToString();
        string querySelect = "SELECT FileName FROM SentRecycle WHERE FileName ='" + fileName  + "'";
        cmd = new SqlCommand(querySelect);
         
        frm.ShowDataGridView();
        cmd.Connection = con;
        
        reader = cmd.ExecuteReader();
    
        if (reader.Read() == true)
        {
            MessageBox.Show("This file already in use!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
            fileNamelist.add(fileName);
            if ((reader != null))
            {
                reader.Close();
            }
            //return; this will finish loop. so removed!
        }
    }
