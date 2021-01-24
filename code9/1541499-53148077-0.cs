                String utga = textBox6.Text;
                String utga1 = "IMSI";
                int loop = 0;
                
                int i = 0;
                int j = 0;
                foreach (string word in words)
                {
                    int j = i+1;
                    if (words[i] == utga)
                    {
                        string loop = words[i+1];
                        if(words[j] == utga1)
                        {
                        MySqlDataAdapter adp1 = new MySqlDataAdapter("Insert into hlr.hlr(IMSI,MSISDN_COLUMN) Values('" + loop + "','" + words[i + 1] + "')", connection);
                        DataTable hlr = new DataTable();
                        adp1.Fill(hlr);
                        dataGridView1.DataSource = hlr;
                        adp1.Dispose();
                        connection.Close();
                        //i = i + too;
                        i++;
                    }
                    else
                    {
                        i++;
                    }
                }    
