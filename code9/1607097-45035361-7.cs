    private void button1_Click(object sender, EventArgs e)
    {
    	foreach(DataGridViewRow row in dataGridView1.Rows)
    	{
    		if(row.Cells[19].Value !== null && (bool)row.Cells[19].Value)//update only changed data
    		{
    			SqlConnection maConnexion = new SqlConnection("Server= localhost; Database= Seica_Takaya;Integrated Security = SSPI; ");
    			maConnexion.Open();
    			SqlCommand command = maConnexion.CreateCommand();
    			command = new SqlCommand("update FailOnly, FailAndPass set FaultCodeByOp=@Fault, RepairingDate=@RD, RepairingTime = @RT, ReportingOperator=@RO", maConnexion);
    			command.Parameters.AddWithValue("@Fault",row.Cells[15].Value != null ? row.Cells[15].Value : DBNull.Value);
    			command.Parameters.AddWithValue("@RD", row.Cells[16].Value != null ? row.Cells[16].Value : DBNull.Value);
    			command.Parameters.AddWithValue("@RT", row.Cells[17].Value != null ? row.Cells[17].Value : DBNull.Value);
    			command.Parameters.AddWithValue("@RO", row.Cells[18].Value != null ? row.Cells[18].Value : DBNull.Value);
    			command.ExecuteNonQuery();
    			maConnexion.Close();
    		}
    	}
    }
