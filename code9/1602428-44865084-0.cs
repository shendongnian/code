    .....
    using (OleDbConnection connection = new OleDbConnection(connetionString))
    {
        sql = @"Insert into EnableOne (Property,Pvalue,Pdefault,PType)
                VALUES(@var1, @var2, @var3, @var4)";
        connection.Open(); 
        using (OleDbCommand cmd1 = new OleDbCommand(sql, connection))
        {
            number = dataGridView1.CurrentCell.RowIndex;
            int numr = dataGridView1.Rows.Count;
            cmd1.Parameters.Add("@var1", OleDbType.VarWChar);
            cmd1.Parameters.Add("@var2", OleDbType.VarWChar);
            cmd1.Parameters.Add("@var3", OleDbType.VarWChar);
            cmd1.Parameters.Add("@var4", OleDbType.VarWChar);
            for (int x = 0; x < numr; x++)
            {
                    cmd1.Parameters["@var1"].Value = dataGridView1.Rows[x].Cells[0].Value.ToString()));
                    cmd1.Parameters["@var2"].Value = dataGridView1.Rows[x].Cells[1].Value.ToString()));
                    cmd1.Parameters["@var3"].Value = dataGridView1.Rows[x].Cells[2].Value.ToString()));
                    cmd1.Parameters["@var4"].Value = dataGridView1.Rows[x].Cells[3].Value.ToString()));
                    cmd1.CommandText = sql;
                    cmd1.ExecuteNonQuery();
                }
            }
        }
     }
