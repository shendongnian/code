            con.Open();
            var hsNxx = new HashSet<int>();
            var hsBex = new HashSet<int>();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
              
                while (rdr.Read())
                {
                    hsBex.Add((int)rdr["Bex"]);
                    hsNxx.Add((int)rdr["Nxx"]);
                }
            }
            
            con.Close();
            string distinctBex =hsBex.Count == 1 ? hsBex.First().ToString() : hsBex.Select(f => f.ToString()).Aggregate((x, y) => x + "," + y);
            this.BEX.Text = distinctBex;
