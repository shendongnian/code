       for (int i = 1; i <= TOTALMEMBERS; i++)
       {
           string[] row = new string[] { i.ToString() };
           ufGview.Rows.Add(row);
       }
       int ji = 0;
       while (sqlDataReader.Read())
       {
            ufGview.Rows[ji].Cells["Column3"].Value = sqlDataReader["id"].ToString();
            ufGview.Rows[ji].Cells["Column1"].Value = sqlDataReader["IdNo"].ToString();
            ufGview.Rows[ji].Cells["Column2"].Value = sqlDataReader["status"].ToString();
                    
          ji++;
        }
