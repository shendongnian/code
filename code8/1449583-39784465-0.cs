            StreamReader r = new StreamReader(f);
             {
                       
               conn.Open();
               while (!r.EndOfStream)
                        {
                            var s = r.ReadLine().Split('\t');
                            string temp = s[1];
                            var temp1 = temp.Split(null);
                            SqlCommand cmd = new SqlCommand("insert into attendance2 values('" + s[0] + "','" + temp1[0] + "','" + temp1[1] + "','" + s[2] + "','" + s[3] + "','" + s[4] + "','" + s[5] + "')", conn);
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
