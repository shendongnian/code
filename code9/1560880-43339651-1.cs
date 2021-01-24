        using (SqlConnection conn = new SqlConnection("Data Source=RC-8573\\SQLEXPRESS;Initial Catalog=DataManagment;Integrated Security=SSPI;MultipleActiveResultSets=True"))
        {
            var projects = new List<Projects>();
            conn.Open();
            using (var cmd = new SqlCommand("getProjects", conn) { CommandType = CommandType.StoredProcedure })
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        var Project = new Projects
                        {
                            project_number = Convert.ToInt32(dr[1].ToString()),
                            project_name = dr[2].ToString(),
                        };
                        projects.Add(Project); 
                        // open new sqldatareader for each project_id >>  need add MultipleActiveResultSets=True to connectionstring(added)
                        using (SqlCommand com = new SqlCommand("SELECT user_name FROM Users WHERE user_id = (SELECT user_id FROM User_Projects WHERE project_number = @project_number)", conn))
                        {
                            com.Parameters.Add("@project_number", Project.project_number);
                            List<string> developerNames = new List<string>();
                            using (SqlDataReader rdrDev = com.ExecuteReader())
                            {
                                if (rdrDev.HasRows)
                                {
                                    while (rdrDev.Read())
                                    {
                                        developerNames.Add((string)rdrDev["user_name"]);
                                    }
                                }
                            }
                            // set names to project object
                            Project.developer_name = string.Join(", ", developerNames);
                        }
                        
                    }
            }
            var js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(projects));
        }
