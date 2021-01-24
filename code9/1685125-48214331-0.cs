     string query = "INSERT INTO LectureTable(Cname) VALUES(@name)";          
    using(SqlCommand cmd = new SqlCommand(query, SqlConnection))
    { 
    SqlParameter param = new SqlParameter("@name", cnameTextBox.Text);
    param.SqlDbType = SqlDbType.String;
    cmd.Parameters.Add(param);
    .....
    }
