    DateTime current = DateTime.Now;
           Console.WriteLine(current);
            SqlConnection conn = new SqlConnection();
            string q = "SELECT @field FROM student";
            SqlDataAdapter da = new SqlDataAdapter(q, conn);
            da.SelectCommand.Parameters.AddWithValue("@field", "snName");
            DataTable dt = new System.Data.DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();
            List<string> names = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                names.Add(dr[0].ToString());
            }
            Console.WriteLine("Fetching {0} data for {1}", names.Count, DateTime.Now - current);
            Console.ReadKey();
