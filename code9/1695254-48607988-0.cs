    var updateCommand = "UPDATE attendances SET ClockOut = @Time Where EmployeeId = @Id and Date = @Date";
    var EmployeeConnectionString = "Data Source=USER-PC;Initial Catalog=1GCAttendanceManagementSystem;Integrated Security=True";
    using(var con2 = new SqlConnection(EmployeeConnectionString))
    {
        using(var cmd = new SqlCommand(updateCommand, con2))
        {
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = txtID.Text;
            cmd.Parameters.Add("@Date", SqlDbType.Date).Value = DateTime.Today;
            cmd.Parameters.Add("@Time", SqlDbType.Time)Value = DateTime.Now.TimeOfDay;
            con2.Open();
            cmd.ExecuteNonQuery();    
        }
    }
