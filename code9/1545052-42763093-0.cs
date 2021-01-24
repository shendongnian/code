    public bool InsertStudent(Student student)
    {
        var db = DAL.Services.SqlServicesPool.HackService;
        using (var connection = db.StartConnection())
        {
            var sqlParam = new SqlParameter[]
          {
            new SqlParameter("@Name", student.Name),
            new SqlParameter("@Lname", student.Lname),
            new SqlParameter("@Phone", student.Phone),
            new SqlParameter("@Email", student.Email),
            new SqlParameter("@Img", student.Img),
            new SqlParameter("@CityId", student.CityId)
          };
          var result = db.Exec(connection, "spInsertNewStudent", sqlParam);
          db.StopConnection(connection);
          return result;
       };
    }
    public class Student
    {
       public string Name { get; set; }
       public string Lname { get; set; }
       public string Phone { get; set; }
       public string Email { get; set; }
       public byte []Img { get; set; }
       public string CityId { get; set; }
    }
