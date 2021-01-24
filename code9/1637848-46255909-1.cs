    private List<Course> GetCourses()
    {
        SqlCommand cmd = new SqlCommand
        {
            cmd.Connection = con;
            cmd.CommandText = "select * from tbl_Class";
        };
        List<Course> courses = new List<Course>();
        SqlDataReader myReader;
        try
        {
            con.Open();
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                Course c = new Course
                {
                    CID = myreader.GetInt32(0),
                    name = myreader.GetString(1)
                };
                courses.Add(c);
             }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Cannot open connection!");
        }
        finally
        {
            if (con != null)
                con.Close();
        }
        return courses;
    }
