    private async void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
    {
            var conString=Properties.Settings.Default.MyConnectionString;
            string query = "SELECT * FROM dbo.Liguanea_Lane2";                    
            
            using(var con = new SqlConnection(conString))
            using(var cmd = new SqlCommand(query, con))
            {
                await con.OpenAsync();
                var reader=await cmd.ExecuteReader();
                while (dr.Read())
                {
                    string scode = dr.GetString(dr.GetOrdinal("code"));
                    comboBox2.Items.Add(scode);
                }
            }
    }
