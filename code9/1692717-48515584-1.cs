        [HttpPost]
        public IHttpActionResult Post(RequestModel studentjson)
        {
            string SQLConnectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(SQLConnectionString))
            {
                conn.Open();
                try
                {
                    foreach (var student in studentjson.data)
                    {
                        if (writetotbl(conn, student.Student))
                        {
                            Console.WriteLine(string.Format("Id:{0}, Student:{1}, Grade:{2}", student.Id, student.Student, student.Grade));
                        }
                        else
                        {
                            Console.WriteLine("Error : " + student.Student);
                        }
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    // make sure the connection is closed
                    if (conn.State != System.Data.ConnectionState.Closed)
                        conn.Close();
                    throw;
                }
            }
        }
