    >  int i = 0;
    >         private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    >         {
    >             if (dataGridView1.Columns[e.ColumnIndex].Name == "btndelete")
    >             {
    >                 using (OleDbConnection conn = new OleDbConnection(sqlCon))
    >                 {
    >                     conn.Open();
    >                     using (OleDbCommand cmd = conn.CreateCommand())
    >                     {
    >                         int id;
    >                         if (this.i > 0)
    >                         {
    >                             id = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[1].Value);
    >                         }
    >                         else
    >                         {
    >                             id = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value);
    >                         }
    >                         cmd.CommandText = @"delete from Table1 where ID=" + id;
    >                         int i = cmd.ExecuteNonQuery();
    >                         if (i > 0)
    >                             MessageBox.Show("Deleted.");
    >                     }
    >                 }
    >             }
    >             dataGridView1.DataSource = BindSource();
    >             i++;
    >         }
