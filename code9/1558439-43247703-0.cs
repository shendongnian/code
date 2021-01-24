        SqlConnection con = new SqlConnection(connection string); //put your connection string there
        SqlCommand insert = new SqlCommand("insert into invtempdb (fullname, quantity, itmbyp, itmprimary, itmtotal) values(@a,@b,@c,@d,@e);", con)
        insert.Parameters.Add("@a",dataGridView1.CurrentRow.Cells[1] );
        insert.Parameters.Add("@b",dataGridView1.CurrentRow.Cells[2] );
        insert.Parameters.Add("@c",dataGridView1.CurrentRow.Cells[3] );
        insert.Parameters.Add("@d",dataGridView1.CurrentRow.Cells[4] );
        insert.Parameters.Add("@e",dataGridView1.CurrentRow.Cells[5] );
        insert.ExecuteNonQuery();
