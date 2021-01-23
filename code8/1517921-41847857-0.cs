        private void Form5_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=xxxxx;Initial Catalog=xxxxx;Integrated Security=True;");
            conn.Open();
            SqlCommand sc = new SqlCommand("  SELECT id, customername+' - '+cast(inserted as varchar(19)) as targ FROM baf where customername>'a' order by customername asc, inserted desc ", conn);
            SqlDataReader reader;
            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("targ", typeof(string));
            dt.Load(reader);
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "targ";
            comboBox1.DataSource = dt;
            conn.Close();
            var select = "SELECT [id],[CustomerName], [email],[CapActual] FROM baf order by id desc";
            var c = new SqlConnection("Data Source=xxxx;Initial Catalog=xxxxx;Integrated Security=True;"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, c);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            var bf = new DataTable("BF");
            ds.Tables.Add(bf);
   
            dataAdapter.Fill(bf);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = bf;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var select = "SELECT [id],[CustomerName],[email],[CapActual] FROM baf where id="+comboBox1.SelectedValue+" order by id desc";
            var c = new SqlConnection("Data Source=xxxxx;Initial Catalog=xxxxxx;Integrated Security=True;"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select,c);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            var bf = new DataTable("BF");
            ds.Tables.Add(bf);
            dataAdapter.Fill(bf);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = bf;
            
            
            
            
            
            
            
            
        }
        }
        }
