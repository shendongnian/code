    private void metroButton1_Click(object sender, EventArgs e)
        {
            SqlConnection maConnexion = new SqlConnection("Server= localhost; Database= Seica_Takaya;Integrated Security = SSPI; ");
            maConnexion.Open();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ((row.Cells[20].Value != null) && (bool)row.Cells[20].Value)
                {
                    SqlCommand command = maConnexion.CreateCommand();
                   
                    command = new SqlCommand("update FailAndPass set Machine=@machine, ProgCode=@pc, BoardName=@BName, BoardNumber=@BNumber, Tester=@T, DateTest=@DT, TimeTest=@TT, TimeStart=@TS, FComponent=@FC, Message=@Mess, TotalTestProg=@TTP, ReadValue=@RV, ValueReference=@VR, PTolerance=@PT, FaultDetail=@FD, RepairingDate=@RD, RepairingTime=@RT, ReportingOperator=@RO, FaultCodeByOP=@FCBO  WHERE SerialNum=@Serial", maConnexion);
                    
                    command.Parameters.AddWithValue("@Machine", row.Cells[1].Value != null ? row.Cells[1].Value : DBNull.Value);
                    command.Parameters.AddWithValue("@Serial", textBox1.Text);
                    command.Parameters.AddWithValue("@pc", row.Cells[3].Value != null ? row.Cells[3].Value : DBNull.Value);
                    command.Parameters.AddWithValue("@BName", row.Cells[4].Value != null ? row.Cells[4].Value : DBNull.Value);
                    command.Parameters.AddWithValue("@BNumber", row.Cells[5].Value != null ? row.Cells[5].Value : DBNull.Value);
                    command.Parameters.AddWithValue("@T", row.Cells[6].Value != null ? row.Cells[6].Value : DBNull.Value);
                    command.Parameters.AddWithValue("@DT", row.Cells[7].Value != null ? row.Cells[7].Value : DBNull.Value);
                    command.Parameters.AddWithValue("@TT", row.Cells[8].Value != null ? row.Cells[8].Value : DBNull.Value);
                    command.Parameters.AddWithValue("@TS", row.Cells[9].Value != null ? row.Cells[9].Value : DBNull.Value);
                    command.Parameters.AddWithValue("@FC", row.Cells[11].Value != null ? row.Cells[11].Value : DBNull.Value);
                    command.Parameters.AddWithValue("@Mess", row.Cells[10].Value != null ? row.Cells[10].Value : DBNull.Value);                   
                    command.Parameters.AddWithValue("@TTP", row.Cells[12].Value != null ? row.Cells[12].Value : DBNull.Value);
                    command.Parameters.AddWithValue("@RV", row.Cells[13].Value != null ? row.Cells[13].Value : DBNull.Value);
                    command.Parameters.AddWithValue("@VR", row.Cells[14].Value != null ? row.Cells[14].Value : DBNull.Value);
                    command.Parameters.AddWithValue("@PT", row.Cells[15].Value != null ? row.Cells[15].Value : DBNull.Value);
                    command.Parameters.AddWithValue("@FD", row.Cells[16].Value != null ? row.Cells[16].Value : DBNull.Value);
                    command.Parameters.AddWithValue("@RD", row.Cells[17].Value != null ? row.Cells[17].Value : DBNull.Value);
                    command.Parameters.AddWithValue("@RT", row.Cells[18].Value != null ? row.Cells[18].Value : DBNull.Value);
                    command.Parameters.AddWithValue("@RO", row.Cells[19].Value != null ? row.Cells[19].Value : DBNull.Value);
                    command.Parameters.AddWithValue("@FCBO", row.Cells[20].Value != null ? row.Cells[20].Value : DBNull.Value);
                    command.ExecuteNonQuery();
                }
            }
