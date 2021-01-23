            string fileName = "state_list.txt";
            var lines = File.ReadLines(fileName);
            Dictionary<string,string> splitted = new Dictionary<string,string>();
            foreach (var line in lines)
            {
                string[] splitter = line.Split(',');
                splitted.Add(splitter[0], splitter[1]); //Add eatch splitted line to dictionary so you can use key and value to insert into table
            }
            string connStr ="server = localhost; user = root; database = sakila; port = 3306; password = xxxxxxxxx;"; // CREATE CONNECTION WITH YOUR DATABASE INFORMATION
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO state_list(code,area) VALUES(@code, @area)";
                foreach (KeyValuePair<string, string> pair in splitted)
                {
                    comm.Parameters.Add("@code", pair.Key);
                    comm.Parameters.Add("@areas", pair.Value);
                    comm.ExecuteNonQuery(); // INSERT EACH PAIR INTO DATABASE
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close(); //CLOSE CONNECTION
