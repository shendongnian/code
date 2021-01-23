            var items=new List<string>();
            using(var con = new SqlConnection(conString))
            using(var cmd = new SqlCommand(query, con))
            {
                await con.OpenAsync();
                var reader=await cmd.ExecuteReader();
                while (dr.Read())
                {
                    string scode = dr.GetString(dr.GetOrdinal("code"));
                    list.Add(scode);
                }
            }
            comboBox2.Items.AddRange(items);
