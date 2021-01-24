       if ((row.Cells[19].Value != null) && (bool)row.Cells[19].Value)
            {
                SqlCommand command = maConnexion.CreateCommand();
                command = new SqlCommand("update FailOnly set Machine=@Machine, ProgCode=@ProgCode, BoardName=@BoardName, BoardNumber=@BoardNumber, Tester=@Tester,DateTest=@DateT,TimeTest=@TT,TimeStart=@TS,FComponent=@FC, MMessage=@Message, TotalTestProg=@TTP, ReadValue=@RV, ValueReference=@VR,PTolerance=@PT , FaultCodeByOp=@Fault, RepairingDate=@RD, RepairingTime = @RT, ReportingOperator=@RO WHERE SerialNum=@Serial", maConnexion);
                command.Parameters.AddWithValue("@Machine", row.Cells[0].Value != null ? row.Cells[0].Value : DBNull.Value);
                command.Parameters.AddWithValue("@Serial", row.Cells[1].Value != null ? row.Cells[1].Value : DBNull.Value);
                command.Parameters.AddWithValue("@ProgCode", row.Cells[2].Value != null ? row.Cells[2].Value : DBNull.Value);
                command.Parameters.AddWithValue("@BoardName", row.Cells[3].Value != null ? row.Cells[3].Value : DBNull.Value);
                command.Parameters.AddWithValue("@BoardNumber", row.Cells[4].Value != null ? row.Cells[4].Value : DBNull.Value);
                command.Parameters.AddWithValue("@Tester", row.Cells[5].Value != null ? row.Cells[5].Value : DBNull.Value);
                command.Parameters.AddWithValue("@DateT", row.Cells[6].Value != null ? row.Cells[6].Value : DBNull.Value);
                command.Parameters.AddWithValue("@TT", row.Cells[7].Value != null ? row.Cells[7].Value : DBNull.Value);
                command.Parameters.AddWithValue("@TS", row.Cells[8].Value != null ? row.Cells[8].Value : DBNull.Value);
                command.Parameters.AddWithValue("@FC", row.Cells[9].Value != null ? row.Cells[9].Value : DBNull.Value);
                command.Parameters.AddWithValue("@Message", row.Cells[10].Value != null ? row.Cells[10].Value : DBNull.Value);
                command.Parameters.AddWithValue("@TTP", row.Cells[11].Value != null ? row.Cells[11].Value : DBNull.Value);
                command.Parameters.AddWithValue("@RV", row.Cells[12].Value != null ? row.Cells[12].Value : DBNull.Value);
                command.Parameters.AddWithValue("@VR", row.Cells[13].Value != null ? row.Cells[13].Value : DBNull.Value);
                command.Parameters.AddWithValue("@PT", row.Cells[14].Value != null ? row.Cells[14].Value : DBNull.Value);
                command.Parameters.AddWithValue("@Fault", row.Cells[15].Value != null ? row.Cells[15].Value : DBNull.Value);
                command.Parameters.AddWithValue("@RD", row.Cells[16].Value != null ? row.Cells[16].Value : DBNull.Value);
                command.Parameters.AddWithValue("@RT", row.Cells[17].Value != null ? row.Cells[17].Value : DBNull.Value);
                command.Parameters.AddWithValue("@RO", row.Cells[18].Value != null ? row.Cells[18].Value : DBNull.Value);
                command.ExecuteNonQuery();
            }
