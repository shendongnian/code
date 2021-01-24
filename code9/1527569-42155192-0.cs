    Please use like below ExP:
       string InputValue="12";
            List<string> listView1 = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                List<string> terms = InputValue.Split(',').ToList();
                terms = terms.Select(s => s.Trim()).ToList();
                //Extract the term to be searched from the list
                string searchTerm = terms.LastOrDefault().ToString().Trim();
                //Return if Search Term is empty
                if (string.IsNullOrEmpty(searchTerm))
                {
                    return new string[0];
                }
                //Populate the terms that need to be filtered out
                List<string> excludeTerms = new List<string>();
                if (terms.Count > 1)
                {
                    terms.RemoveAt(terms.Count - 1);
                    excludeTerms = terms;
                }
               conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["CON"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "select [desc],[enchimento] from vidros where " +
                    " desempenho = @emp";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@emp", searchTerm);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            listView1.Add(string.Format("{0}-{1}", sdr["desc"], sdr["enchimento"]));
                        }
                    }
                    conn.Close();
                }
                return listView1.ToArray();
