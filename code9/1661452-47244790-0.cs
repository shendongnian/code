      private void Form1_Load(object sender, EventArgs e)
        {              
            SqlConnection con = new SqlConnection(@"Data Source=WINDOWS-PC\SQLSERVER;Initial Catalog=World;Integrated Security=True");
            string sql = "Select * from Paises";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader sdr;
            try
            {
                con.Open();
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    string Pais = sdr.GetString(4);
                    comboBox1.Items.Add(Pais);
                }                                                                        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=WINDOWS-PC\SQLSERVER;Initial Catalog=World;Integrated Security=True");
            string sql = "Select Cod from Paises where Nome = '" + comboBox1.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader sdr;
            try
            {
                con.Open();
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    string PaisCod = sdr.GetValue(0).ToString();
                    Cod.Text = PaisCod;
                }
                sdr.Close();
                string a = "Select Estados from Estados where PaisCod = " + Cod.Text + "";
                SqlCommand cm1 = new SqlCommand(a , con);
                SqlDataReader sd1;
                sd1 = cm1.ExecuteReader();
                while(sd1.Read())
                {
                    string aqw = sd1.GetString(0);
                    comboBox2.Items.Add(aqw);
                }
                sd1.Close();     
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=WINDOWS-PC\SQLSERVER;Initial Catalog=World;Integrated Security=True");
            string b = "Select Cod from Estados where Estados = '" + comboBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(b , con);
            SqlDataReader sdr;
            try
            {
                con.Open();
                sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    string Cod = sdr.GetValue(0).ToString();
                    Ci_Cod.Text = Cod;
                }
                sdr.Close();
                string c = "Select Cidade from Cidades where Ci_Cod = " + Ci_Cod.Text + "";
                SqlCommand cm1 = new SqlCommand(c , con);
                SqlDataReader sd1;
                sd1 = cm1.ExecuteReader();
                while(sd1.Read())
                {
                    string Cidades = sd1.GetString(0);
                    comboBox3.Items.Add(Cidades);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }   
