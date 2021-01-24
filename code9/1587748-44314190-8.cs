    public class DAL
    {
      public static string connectionString = ...;
      public IEnumberable<MyData> GetMyClassByRange(DateTime start, DateTime end)
      {
        var sql = @"
    SELECT Schedule_Date, Start_Time, End_Time, Employee_Name, Job_Title
    FROM My_Employee_Schedule ed
    JOIN My_Employee e
      ON ed.Emp_ID=e.Employee_Id
    JOIN My_Job_Type jt
      ON ed.Job_ID=jt.Job_Type_Id
    WHERE Start_Time BETWEEN @startReportDate AND @endReportDate";
        conn = new SqlConnection(connectionString);
        conn.Open();
        var data = conn.Query<MyData>(sql, new { startReportDate=startDate, endReportDate=endDate});
        conn.Close();
      }
    }
