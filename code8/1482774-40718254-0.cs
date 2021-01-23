    public class Student
    {
        public int Student_id { get; set; }
        public string Student_name { get; set; }
        public string Student_mark { get; set; }
    }
    public class DataService
    {
        static string connectionString;
        public static String Name = "Data Service.";
        private static ObservableCollection<Student> _allStudents = new ObservableCollection<Student>();
        public static ObservableCollection<Student> GetStudents()
        {
            try
            {
                string server = "127.0.0.1";
                string database = "sakila";
                string user = "root";
                string pswd = "!QAZ2wsx";
                connectionString = "Server = " + server + ";database = " + database + ";uid = " + user + ";password = " + pswd + ";SslMode=None;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand getCommand = connection.CreateCommand();
                    getCommand.CommandText = "SELECT * FROM student";
                    using (MySqlDataReader reader = getCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _allStudents.Add(new Student() { Student_id = reader.GetInt32(0), Student_name = reader.GetString(1), Student_mark = reader.GetString(2) });
                        }
                    }
                }
            }
            catch (MySqlException sqlex)
            {
                // Handle it :)
            }
            return _allStudents;
        }
        public static bool InsertNewStudent(Student newStudent)
        {
            // Insert to the collection and update DB
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand insertCommand = connection.CreateCommand();
                    insertCommand.CommandText = "INSERT INTO student(student_id, student_name, student_mark)VALUES(@student_id, @student_name,@student_mark)";
                    insertCommand.Parameters.AddWithValue("@student_id", newStudent.Student_id);
                    insertCommand.Parameters.AddWithValue("@student_name", newStudent.Student_name);
                    insertCommand.Parameters.AddWithValue("@student_mark", newStudent.Student_mark);
                    insertCommand.ExecuteNonQuery();                   
                    return true;
                }
            }
            catch (MySqlException sqlex)
            {
                return false;
            }
        }
        public static bool UpdateStudent(Student Student)
        { 
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand insertCommand = connection.CreateCommand();
                    insertCommand.CommandText = "Update student Set student_name= @student_name, student_mark=@student_mark Where student_id =@student_id";
                    insertCommand.Parameters.AddWithValue("@student_id", Student.Student_id);
                    insertCommand.Parameters.AddWithValue("@student_name", Student.Student_name);
                    insertCommand.Parameters.AddWithValue("@student_mark", Student.Student_mark);
                    insertCommand.ExecuteNonQuery();
                    return true;
                }
            }
            catch (MySqlException sqlex)
            {
                // Don't forget to handle it
                return false;
            }
        }
        public static bool Delete(Student Student)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand insertCommand = connection.CreateCommand();
                    insertCommand.CommandText = "Delete from sakila.student where student_id =@student_id";
                    insertCommand.Parameters.AddWithValue("@student_id", Student.Student_id);
                    insertCommand.ExecuteNonQuery();
                    return true;
                }
            }
            catch (MySqlException sqlex)
            {                
                return false;
            }
        } 
    }
