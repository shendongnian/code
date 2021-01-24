    command.CommandText = @"UPDATE TimeinTimeout 
                            SET HoursWorked = @1-[InTime],
                            OutTime = @2
                            WHERE EmployeeID = @3 AND InDate = @4";
    command.Parameters.Add("@1", OleDbType.Date).Value = DateTime.Now;
    command.Parameters.Add("@2", OleDbType.Date).Value = DateTime.Now;
    // Is this field really a string? 
    // If not use the appropriate type and convert the textbox.text
    command.Parameters.Add("@3", OleDbType.VarWChar).Value = textBox1.Text;
    command.Parameters.Add("@4", OleDbType.Date) = DateTime.Today;
    command.ExecuteNonQuery();
