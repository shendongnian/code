    var query="INSERT INTO [Data$] " +
                     "([Title],[Name],[DayOfWeek],[Approval State],[Date],[User ID],[Week],[Project Code],[Project Regular Hours],[Project Overtime Hours],[Sick],[Vacation],[Holiday],[Unpaid Leave],[Other],[Timesheet URL])" +
                     "VALUES(@Title,@Name,@DayOfWeek,@ApprovalState,@Date,@UserID,@Week,@ProjectCode,@ProjectRegularHours,@ProjectOvertimeHours,@Sick,@Vacation,@Holiday,@UnpaidLeave,@Other,@TimesheetURL)";
    var cmd1 = new OleDbCommand(query, cn);
    cmd1.Parameters.Add("@Title",OleDbType.VarWChar,20 );
    cmd1.Parameters.Add("@Name",OleDbType.VarWChar,20 );
    cmd1.Parameters.Add("@DayOfWeek",OleDbType.VarWChar,20 );
    ...      
  
    cmd1.Parameters.Add("@ProjectRegularHours",OleDbType.Decimal,19,4);
    
    for (int i = 0; i < Grid.RowCount; i++)
    {
        cmd1.Parameters["@Title"].Value = Grid.GetRowCellValue(i,"Title");
        ...
        cmd1.Parameters["@ProjectRegularHours"].Value = (decimal)Grid.GetRowCellValue(i,"ProjectRegularHours"))
        cmd1.ExecuteNonQuery();
    }
 
