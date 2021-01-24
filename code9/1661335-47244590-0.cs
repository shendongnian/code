        [WebMethod]
        public void GetStudent () {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename='C:\\Users\\Abdul Basit Mehmood\\Documents\\Visual Studio 2012\\WebSites\\WebSite1\\App_Data\\Database.mdf';Integrated Security= True");
            List<StudentsList> stu = new List<StudentsList>();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From Student";
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                StudentsList student = new StudentsList();
                student.Id = Convert.ToInt32(DR["Id"]);
                student.name = DR["name"].ToString();
                student.fname = DR["fname"].ToString();
                student.email = DR["email"].ToString();
                student.contact = DR["contact"].ToString();
                student.Pname = DR["Pname"].ToString();
                student.Cname = DR["Cname"].ToString();
                stu.Add(student); //Changed line: Changed variable name to stu which is the list variable declared earlier.
    
            }
        JavaScriptSerializer js = new JavaScriptSerializer(); //changed line : Removed the invalid parameter to the constructor of JavaScriptSerializer class
        Context.Response.Write(js.Serializ(stu)); //changed line : Used the correct stu list variable declared at the starting of the method.
    }
