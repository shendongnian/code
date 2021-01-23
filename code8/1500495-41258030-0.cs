    private void btnSearch_Click(object sender, EventArgs e)
    {
        DA.SelectCommand = new OleDbCommand("SELECT * FROM INQUIREt WHERE InqID=@ID", CON);
        DA.SelectCommand.Parameters.Add("@ID", OleDbType.VarChar).Value = txtInqID.Text;	
        DS.Clear();
        DA.Fill(DS);
        dataGridView.DataSource = null;
        dataGridView.DataSource = DS.Tables[0];
    }
    
    private void btnNameSearch_Click(object sender, EventArgs e)
    {
    	DA.SelectCommand = new OleDbCommand("SELECT * FROM INQUIREt WHERE InqName=@name", CON);
    	DA.SelectCommand.Parameters.Add("@name", OleDbType.VarChar).Value = txtInqName.Text;
    	DS.Clear();
        DA.Fill(DS);
        dataGridView.DataSource = null;
        dataGridView.DataSource = DS.Tables[0];
    }
