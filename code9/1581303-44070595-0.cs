    cn.Open();
    SqlCommand cmd = cn.CreateCommand();
    cmd.CommandType = CommandType.Text;
    cmd.CommandText = "SELECT et.FirstName,et.LastName,at.Date,at.Time,at.Day from 
    Attendance at left JOIN 
    EmployeeTable et ON at.EmployeeID = et.EmployeeID 
    where at.Sn=@Sn and (at.[Date] between @SD and @ED)
    Order by Attendance.AttendanceID";
    cmd.Parameters.Add(new SqlParameter("@Sn", txtSn.Text));
    cmd.Parameters.Add(new SqlParameter("@SD", DTPStart.Text));
    cmd.Parameters.Add(new SqlParameter("@ED", DTPEnd.Text));
    cmd.ExecuteNonQuery();
    DataTable dt = new DataTable();
    SqlDataAdapter sda = new SqlDataAdapter(cmd);
    sda.Fill(dt);
    dataGridView2.DataSource = dt;
    cn.Close();
