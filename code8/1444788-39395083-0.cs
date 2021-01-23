        static void Main(string[] args)
        {
            List<person> FilteredPeople = GetPeople("D");
        }
        static List<person> GetPeople(string condition)
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from dbo.contact WHERE DName LIKE @mycondition", connection))
	            {
                     cmd.Parameters.Add(new SqlParameter("mycondition", condition));
                     SqlDataReader dr = cmd.ExecuteReader();
                     List<person> persons = new List<person>();
                    while (dr.Read())
                    {
                         person p = new person();
                         p.idValue = dr["Id"].ToString();
                         p.DName = dr["DName"].ToString();
                         p.FName = dr["FName"].ToString();
                         persons.Add(p);
                     }
                     return persons;
                }
            }
            catch { }
        }
