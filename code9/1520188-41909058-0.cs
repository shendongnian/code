    private void Form1_Load(object sender, System.EventArgs e)
      {
          SqlConnection conn2 = new SqlConnection("Data Source=DIEGOPC;Initial Catalog=Studio;Integrated Security=True;");
            conn2.Open();
            SqlCommand sc = new SqlCommand("SELECT Nome FROM DClub order by Nome", conn2);
            SqlDataReader reader;
            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Nome", typeof(string));
            dt.Load(reader);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "Nome";
            comboBox1.DisplayMember = "Nome";
            conn2.Close();
      }
