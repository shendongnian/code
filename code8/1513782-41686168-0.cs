    namespace BusinessLayer
    {
        public class StudentBusinessLayer
        {
            public List<Student> getStudents(string storedProcedure)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
                {
                    List<Student> students = new List<Student>();
                    SqlCommand comm = new SqlCommand(storedProcedure, conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader rdr = comm.ExecuteReader();
                    while (rdr.Read())
                    {
                       Student s = new Student();
                       s.id = Convert.ToInt32(rdr["id"]);
                       s.Name = rdr["Name"].ToString();
                       s.TotalMarks = Convert.ToInt32(rdr["TotalMarks"]);
                        students.Add(s);
                    }
                }
                return students;
            }
        }
    }
