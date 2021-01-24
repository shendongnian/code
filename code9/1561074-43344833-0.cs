    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
    if(e.RowIndex >= 0)
    {
        DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells[0];
       // ******** e.rowindex shows -1 value.
        if (cb.Value != null)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select rate FROM Ratemaster where Packagetype = '" + comboBox1.Text +
              "' AND Tickettype ='" + ComboboxColumn.Selected + "' ", con);
             SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dataGridView1.Rows[0].Cells[1].Value = dr[0].ToString();
                //dataGridView1.Rows[e.RowIndex].Cells[1].Value = "hi";
            }
            else
            {
                //txtRate.Text = "0";
            }
            con.Close();
         }
        }
