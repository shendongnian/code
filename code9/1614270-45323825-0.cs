    // a & b are cell numbers for respective cells
    // change to any number representing the cell order
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        if ((row.Cells[20].Value != null) && (bool)row.Cells[20].Value)
        {
            SqlCommand command = maConnexion.CreateCommand();
    
            command = new SqlCommand("update FailAndPass set Machine=@machine, ProgCode=@pc, BoardName=@BName, BoardNumber=@BNumber, Tester=@T, DateTest=@DT, TimeTest=@TT, TimeStart=@TS, FComponent=@FC, Message=@Mess, TotalTestProg=@TTP, ReadValue=@RV, ValueReference=@VR, PTolerance=@PT, FaultCodeByOP=@FCBO, FaultDetail=@FD,  RepairingDate=@RD, RepairingTime = @RT, ReportingOperator=@RO WHERE SerialNum=@Serial", maConnexion);
            // other parameters
    
            // integer value parameter example
            command.Parameters.Add("@pc", SqlDbType.Int).Value = row.Cells[a].Value != null ? row.Cells[a]Value : (object)DBNull.Value;
            // string value parameter example
            command.Parameters.Add("@BName", SqlDbType.NVarChar).Value = (row.Cells[b].Value != null ? (object)row.Cells[b].Value : (object)DBNull.Value).ToString();
    
            // other parameters
            command.ExecuteNonQuery();
    
        }
    }
    // other stuff
