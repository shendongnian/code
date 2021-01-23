    private void ShowDetails(int UserId)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=local\s08r2;Initial Catalog=Demo;User id=sa;Password=sa";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(@"
               select anUserID from the_setsubjcontact where acSubject = @acSubjec", con);
    da.SelectCommand.Parameters.AddWithValue(@acSubjec, UserId.ToString());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
    
            }
    
    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
    
            //User selected a cell (show the first cell in the row)
            if (dgv.SelectedCells.Count > 0)
                txtAcFieldSA.Text = dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
    ShowDetails(int.Parse(txtAcFieldSA.Text));
    
        }
